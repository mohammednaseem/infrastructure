az ad sp create-for-rbac --name nsm_kobe_klster_master_api_sp
az account set --subscription "My Demos"


# Specify the Istio version that will be leveraged throughout these instructions
$ISTIO_VERSION="1.4.0"

# Enforce TLS 1.2
[Net.ServicePointManager]::SecurityProtocol = "tls12"
$ProgressPreference = 'SilentlyContinue'; Invoke-WebRequest -URI "https://github.com/istio/istio/releases/download/$ISTIO_VERSION/istio-$ISTIO_VERSION-win.zip" -OutFile "istio-$ISTIO_VERSION.zip"
Expand-Archive -Path "istio-$ISTIO_VERSION.zip" -DestinationPath .

# win10 on azure
istioctl manifest apply -f D:\kube\aksistio\aksistio\KubeYaml\istio\istio.aks.yaml --logtostderr --set installPackagePath=istioctl  --logtostderr --set installPackagePath=C:\Kube\cloudnative\aksistio\KubeYaml\istio\istio-1.4.0\install\kubernetes\operator\charts
# my local box
istioctl  manifest apply -f D:\kube\aksistio\aksistio\KubeYaml\istio\istio.aks.yaml --logtostderr --set installPackagePath=C:\Users\hp\Documents\istio-1.4.0\install\kubernetes\operator\charts
istioctl manifest apply -f istio.aks.yaml --logtostderr --set installPackagePath=./install/kubernetes/operator/charts

kubectl create namespace istio-system --save-config
kubectl apply -f C:\Kube\cloudnative\aksistio\KubeYaml\kiali.yaml
kubectl apply -f C:\Kube\cloudnative\aksistio\KubeYaml\grafana.yaml

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

az acr login -n emerxo

kubectl create secret docker-registry topsecretregistryconnection connection --docker-server dockerstore.azurecr.io --docker-email naseem.mohammed@slkgroup.com --docker-username=dockerstore --docker-password nTN/lSTFLemDqR5NF8lV0q221cReuOPo

az aks get-credentials --name malxxdtax -g OneSimRG --admin

az aks create --resource-group oneSimRG --name malter --generate-ssh-keys --aad-server-app-id 349356c2-a9c204d6d59f --aad-server-app-secret Cit89K8/xm]? --aad-client-app-id ce4b1527180 --aad-tenant-id 5d528d1a65b7 --service-principal 5301f7f8b2 --client-secret 2f868008eeb2b --node_count=2
 

