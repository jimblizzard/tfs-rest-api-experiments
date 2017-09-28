# List-all-tp-in-vsts-account.ps1 --- or tfs team project collection
# List all the team projects in a VSTS account or a TFS team project collection 
# For API reference, see: https://www.visualstudio.com/en-us/docs/integrate/api/tfs/projects

$version = '1.0'
$account = '{yourVstsAccount}'            # only the account name itself 
$resource = '/projects'                   # this is what you want to get
$collection = '/{collectionName}'         # '/[{collectionName}]' --- optional for VSTS 
$instance = '{machineName:8080/tfs}'      # for VSTS use this: '$account.visualstudio.com'
$pat = '{your PAT goes here}'             # see https://docs.microsoft.com/en-us/vsts/accounts/use-personal-access-tokens-to-authenticate
$encodedPat = [System.Convert]::ToBase64String([System.Text.Encoding]::UTF8.GetBytes(":$pat"))
 
# Build the url to list the projects
$listurl = 'https://' + $instance + $collection + '/_apis' + $resource + '?api-version=' + $version

Write-Output $listurl # doing this to make sure the URL looks good... helps with troubleshooting

# Call the REST API
$resp = Invoke-RestMethod -Uri $listurl -Headers @{Authorization = "Basic $encodedPat"}

Write-Output $resp.value