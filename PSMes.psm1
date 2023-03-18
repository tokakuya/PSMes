# Find Module Path
$moduleName = "PSMes";
$dllName = "$moduleName.dll";
$cachePath = Join-Path $env:TMP "__cache\$moduleName";
$tempPath = Join-Path $cachePath ([guid]::NewGuid().ToString());

if (Test-Path ".\$dllName")
{
    $directory = Split-Path (Resolve-Path ".\$dllName").Path -Parent;
    Copy-Item -Path $directory -Destination $tempPath -Force -Recurse;
    $path = Join-Path $tempPath $dllName;
}
else
{
    $moduleRoot = (Get-Module -ListAvailable -Name $moduleName).ModuleBase;
    Copy-Item -Path $moduleRoot -Destination $tempPath -Force -Recurse;
    $path = Join-Path $tempPath $dllName;
}

# Import as DyanmicModule
$module = Import-Module $path -PassThru
Export-ModuleMember -Variable * -Cmdlet *;