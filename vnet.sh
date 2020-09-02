$RgName="nmAKS"
$Location="southeastasia"

# Create a resource group.
az group create --name $RgName --location $Location

# Create a virtual network 
# Create a front-end subnet.
az network vnet create --name MyVnet --resource-group $RgName --location $Location --address-prefix 10.0.0.0/16 --subnet-name MySubnet-FrontEnd --subnet-prefix 10.0.1.0/24 

# Create a back-end subnet.
az network vnet subnet create --address-prefix 10.0.2.0/24 --name MySubnet-BackEnd --resource-group $RgName --vnet-name MyVnet

################# front end nsg + rules + associatation ####################
# Create a network security group for the front-end subnet.
az network nsg create   --resource-group $RgName --name MyNsg-FrontEnd --location $Location

# Create an NSG rule to allow HTTP traffic in from the Internet to the front-end subnet.
az network nsg rule create --resource-group $RgName --nsg-name MyNsg-FrontEnd --name Allow-HTTP-All --access Allow --protocol Tcp --direction Inbound --priority 100 --source-address-prefix Internet --source-port-range "*" --destination-address-prefix "*" --destination-port-range 80

# Create an NSG rule to allow RDP traffic in from the Internet to the front-end subnet.
#az network nsg rule create --resource-group $RgName --nsg-name MyNsg-FrontEnd --name Allow-SSH-All --access Allow --protocol Tcp --direction Inbound --priority 300 --source-address-prefix Internet --source-port-range "*" --destination-address-prefix "*" --destination-port-range 3389

# Associate the front-end NSG to the front-end subnet.
az network vnet subnet update --vnet-name MyVnet --name MySubnet-FrontEnd --resource-group $RgName --network-security-group MyNsg-FrontEnd
################# front end nsg + rules + associatation ####################



################# back end nsg + rules + associatation ####################
# Create a network security group for back-end subnet.
az network nsg create --resource-group $RgName --name MyNsg-BackEnd --location $Location

# Create an NSG rule to allow MySQL traffic from the front-end subnet to the back-end subnet.
az network nsg rule create --resource-group $RgName --nsg-name MyNsg-BackEnd --name Allow-MySql-FrontEnd --access Allow --protocol Tcp --direction Inbound --priority 100 --source-address-prefix 10.0.1.0/24 --source-port-range "*" --destination-address-prefix "*" --destination-port-range 3306

# Create an NSG rule to allow SSH traffic from the front-end to the back-end subnet.
#az network nsg rule create --resource-group $RgName --nsg-name MyNsg-BackEnd --name Allow-SSH-All --access Allow --protocol Tcp --direction Inbound --priority 200 --source-address-prefix 10.0.1.0/24 --source-port-range "*" --destination-address-prefix "*" --destination-port-range 22
 
# Associate the back-end NSG to the back-end subnet.
az network vnet subnet update --vnet-name MyVnet --name MySubnet-BackEnd --resource-group $RgName --network-security-group MyNsg-BackEnd
################# back end nsg + rules + associatation ####################



# Create a public IP address for the web server VM.
az network public-ip create --resource-group $RgName --name MyPublicIP-Web

# Create a NIC for the web server VM.
az network nic create   --resource-group $RgName   --name MyNic-Web   --vnet-name MyVnet   --subnet MySubnet-FrontEnd   --network-security-group MyNsg-FrontEnd   --public-ip-address MyPublicIP-Web

#Create a Web Server VM in the front-end subnet.
#az vm create   --resource-group $RgName   --name MyVm-Web   --nics MyNic-Web   --image UbuntuLTS   --admin-username azureadmin   --ssh-dest-key-path "C:/Users/hp/.ssh/id_rsa.pub"
#az vm delete --resource-group $RgName   --name MyVm-Web --nics MyNic-Web --image win2016datacenter --admin-username "azureuser" --admin-password "Azureuser1!Azure"
az vm create --resource-group $RgName   --name MyVm-Weber --nics MyNic-Web --image win2016datacenter --admin-username "azureuser" --admin-password "Azureuser1!Azure"

# Create a public IP address for the MySQL VM.
az network public-ip create --resource-group $RgName   --name MyPublicIP-Sql 

# Create a NIC for the MySQL VM.
az network nic create  --resource-group $RgName --name MyNic-Sql --vnet-name MyVnet --subnet MySubnet-BackEnd --network-security-group MyNsg-BackEnd --public-ip-address MyPublicIP-Sql

# Create a MySQL VM in the back-end subnet.
#az vm create --resource-group $RgName --name MyVm-Sql --nics MyNic-Sql --image UbuntuLTS --admin-username azureadmin --generate-ssh-keys
az vm create --resource-group $RgName   --name MyVm-Sql --nics MyNic-Sql --image win2016datacenter --admin-username azureuser --admin-password Azureuser1!Azure

az network vnet subnet list --resource-group nmAKS  --vnet-name MyVnet --query "[0].id" --output tsv


az aks create --resource-group $RgName   --name nmCluster   --network-plugin azure  --vnet-subnet-id "/subscriptions/ddf968e5-2304-417f-b000-4a763a8e27af/resourceGroups/nmAKS/providers/Microsoft.Network/virtualNetworks/MyVnet/subnets/MySubnet-FrontEnd"   --docker-bridge-address 172.17.0.1/16   --dns-service-ip 10.2.0.10     --service-cidr 10.2.0.0/24   --generate-ssh-keys
  