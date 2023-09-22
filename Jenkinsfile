pipeline {
    environment {
      branchname =  env.BRANCH_NAME.toLowerCase()
      kubeconfig = getKubeconf(env.branchname)
      registryCredential = 'jenkins_registry'
      namespace = "${env.branchname == 'development' ? 'sme-agendador-dev' : env.branchname == 'release' ? 'sme-agendador-hom' : env.branchname == 'release-r2' ? 'sme-agendador-hom2' : 'sme-agendador' }" 
    }
  
    agent {
      node { label 'builder' }
    }

    options {
      buildDiscarder(logRotator(numToKeepStr: '10', artifactNumToKeepStr: '10'))
      disableConcurrentBuilds()
      skipDefaultCheckout()
    }
  
    stages {

        stage('CheckOut') {            
            steps { checkout scm }            
        }

        stage('AnaliseCodigo') {
          agent { node { label 'dotnet5-sonar' } }
          when { branch 'development' }
          steps {
             checkout scm
              withSonarQubeEnv('sonarqube-local'){
                sh 'dotnet-sonarscanner begin /k:"SME-Worker-Agendador" /d:sonar.cs.opencover.reportsPaths="coverage.opencover.xml" /d:sonar.coverage.exclusions="**Test*.cs"'
                sh 'dotnet build SME-Worker-Agendador.sln'
                sh 'dotnet-sonarscanner end'
            }
          }
        }

        stage('Build') {
          when { anyOf { branch 'master'; branch 'main'; branch "release-r2"; branch 'development'; branch 'release';  } } 
          steps {
            script {
              imagename1 = "registry.sme.prefeitura.sp.gov.br/${env.branchname}/sme-worker-agendador"
              dockerImage1 = docker.build(imagename1, "-f src/SME.Worker.Agendador.Api/Dockerfile .")
              docker.withRegistry( 'https://registry.sme.prefeitura.sp.gov.br', registryCredential ) {
              dockerImage1.push()
              }
              sh "docker rmi $imagename1"
            }
          }
        }
        
        stage('Deploy'){
            when { anyOf {  branch 'master'; branch 'main'; branch 'development'; branch 'release'; branch 'release-r2';  } }        
            steps {
                script{

                    withCredentials([file(credentialsId: "${kubeconfig}", variable: 'config')]){
                            sh('rm -f '+"$home"+'/.kube/config')
                            sh('cp $config '+"$home"+'/.kube/config')
                            sh "kubectl rollout restart deployment/sme-worker-agendador -n ${namespace}"
                            sh('rm -f '+"$home"+'/.kube/config')
                    }
                }
            }           
        }    
    }

  post {
    success { sendTelegram("🚀 Job Name: ${JOB_NAME} \nBuild: ${BUILD_DISPLAY_NAME} \nStatus: Success \nLog: \n${env.BUILD_URL}console") }
    unstable { sendTelegram("💣 Job Name: ${JOB_NAME} \nBuild: ${BUILD_DISPLAY_NAME} \nStatus: Unstable \nLog: \n${env.BUILD_URL}console") }
    failure { sendTelegram("💥 Job Name: ${JOB_NAME} \nBuild: ${BUILD_DISPLAY_NAME} \nStatus: Failure \nLog: \n${env.BUILD_URL}console") }
    aborted { sendTelegram ("😥 Job Name: ${JOB_NAME} \nBuild: ${BUILD_DISPLAY_NAME} \nStatus: Aborted \nLog: \n${env.BUILD_URL}console") }
  }
}
def sendTelegram(message) {
    def encodedMessage = URLEncoder.encode(message, "UTF-8")
    withCredentials([string(credentialsId: 'telegramToken', variable: 'TOKEN'),
    string(credentialsId: 'telegramChatId', variable: 'CHAT_ID')]) {
        response = httpRequest (consoleLogResponseBody: true,
                contentType: 'APPLICATION_JSON',
                httpMode: 'GET',
                url: 'https://api.telegram.org/bot'+"$TOKEN"+'/sendMessage?text='+encodedMessage+'&chat_id='+"$CHAT_ID"+'&disable_web_page_preview=true',
                validResponseCodes: '200')
        return response
    }
}
def getKubeconf(branchName) {
    if("main".equals(branchName)) { return "config_prd"; }
    else if ("master".equals(branchName)) { return "config_prd"; }
    else if ("release-r2".equals(branchName)) { return "config_release"; }
    else if ("release".equals(branchName)) { return "config_release"; }
    else if ("development".equals(branchName)) { return "config_release"; }  
}
