[reflection.assembly]::LoadFile($PSScriptRoot + "/bin/Debug/netstandard2.0/FundacjaBT.EventTool.dll")

$Api = New-Object FundacjaBT.EventTool.ApiClient
$Api.Address = [uri]"http://localhost:8000/"

$Cred = (Get-Credential).GetNetworkCredential()
$Cred.Domain = $Api.Address.DnsSafeHost

$Api.Connect($Cred)
