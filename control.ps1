az ad sp create-for-rbac --name nsm_kobe_klster_master_api_sp
az account set --subscription "My Demos"


# Specify the Istio version that will be leveraged throughout these instructions
$ISTIO_VERSION="1.4.0"

# Enforce TLS 1.2
[Net.ServicePointManager]::SecurityProtocol = "tls12"
$ProgressPreference = 'SilentlyContinue'; Invoke-WebRequest -URI "https://github.com/istio/istio/releases/download/$ISTIO_VERSION/istio-$ISTIO_VERSION-win.zip" -OutFile "istio-$ISTIO_VERSION.zip"
Expand-Archive -Path "istio-$ISTIO_VERSION.zip" -DestinationPath .

# win10 on azure
istioctl manifest apply -f D:\kube\aksistio\aksistio\KubeYaml\istio\istio.aks.yaml --logtostderr --set installPackagePath=istioctl  --logtostderr --set installPackagePath=D:\kube\istio-1.4.0\install\kubernetes\operator\charts
# my local box
istioctl  manifest apply -f D:\kube\aksistio\aksistio\KubeYaml\istio\istio.aks.yaml --logtostderr --set installPackagePath=C:\Users\hp\Documents\istio-1.4.0\install\kubernetes\operator\charts
istioctl manifest apply -f istio.aks.yaml --logtostderr --set installPackagePath=./install/kubernetes/operator/charts


kubectl apply -f D:\kube\aksistio\aksistio\KubeYaml\istio\kiali.yaml
kubectl apply -f D:\kube\aksistio\aksistio\KubeYaml\istio\grafana.yaml

kubectl create namespace nm
kubectl label namespace nm istio-injection=enabled

kubectl create namespace ckad
kubectl label namespace ckad istio-injection=enabled

kubectl get svc --namespace istio-system --output wide
kubectl get pods --namespace istio-system


istioctl dashboard grafana
istioctl dashboard prometheus
istioctl dashboard jaeger
istioctl dashboard kiali

istioctl dashboard envoy <pod-name>.<namespace>

az acr login -n dockerstore

kubectl create secret docker-registry topsecretregistryconnection connection --docker-server dockeec.io --docker-email naem.moup.com --docker-username=dock tore --docker-password nTN/lSTF q221cReuOPo

az aks get-credentials --name malter -g OneSimRG --admin

az aks create --resource-group onmRG --name mater --generate-ssh-keys --aad-server-app-id 349356-b9c204d6d59f --aad-server-app-secret /.yto.:HRT4Hcdh1N --aad-client-app-id ce4b1fd8-0726527180 --aad-tenant-id 5d528a6b2-d70b3d1a65b7 --service-principal 5301fa3ed8007f8b2 --client-secret GsziiY9g2iSp-eJSq. --node_count=2
 

