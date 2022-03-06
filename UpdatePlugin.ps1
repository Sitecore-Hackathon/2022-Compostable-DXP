# Set plugin variables


$pluginNameOne = "Primo.DevEx.Extensibility.Hackathon.1.0.0"
$pluginNameTwo = "Primo.DevEx.Extensibility.Indexing.1.0.0"
$pluginNuspecNameOne = $pluginNameOne + ".nupkg"
$pluginNuspecNameTwo = $pluginNameTwo + ".nupkg"
$pluginSourcePathOne = ".\\src\\Primo.DevEx.Extensibility.Plugin\\bin\\Debug\\"
$pluginSourcePathTwo = ".\\src\\Primo.DevEx.Extensibility.Indexing\\bin\\Debug\\"
$pluginDestinationPath = ".\\LocalPlugins\\"
$pluginDestinationCache = ".\\.sitecore\\package-cache\\nuget\\"

# Validate presence of .nuspec for the plugin
if (-not(Test-Path -Path $pluginSourcePathOne$pluginNuspecNameOne -PathType Leaf))
{
	Write-Error "$pluginSourcePathOne$pluginNuspecNameOne Not Found."
}

# Validate presence of .nuspec for the plugin
if (-not(Test-Path -Path $pluginSourcePathTwo$pluginNuspecNameTwo -PathType Leaf))
{
	Write-Error "$pluginSourcePathTwo$pluginNuspecNameTwo Not Found."
}

# Clean-up existing plugin installation
Remove-Item -Path $pluginDestinationPath$pluginNuspecNameOne
Write-Host $pluginDestinationCache$pluginNameOne
if (Test-Path -Path $pluginDestinationCache$pluginNameOne)
{
	Remove-Item -LiteralPath $pluginDestinationCache$pluginNameOne -Force -Recurse
}

# Clean-up existing plugin installation
Remove-Item -Path $pluginDestinationPath$pluginNuspecNameTwo
if (Test-Path -Path $pluginDestinationCache$pluginNameTwo)
{
	Remove-Item -LiteralPath $pluginDestinationCache$pluginNameTwo -Force -Recurse
}

#Copy item
Copy-Item $pluginSourcePathOne$pluginNuspecNameOne $pluginDestinationPath$pluginNuspecNameOne
Copy-Item $pluginSourcePathTwo$pluginNuspecNameTwo $pluginDestinationPath$pluginNuspecNameTwo
Write-Host "Plugins updated successfully" -ForegroundColor Green