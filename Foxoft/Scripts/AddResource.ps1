param(
    [string]$Key,
    [string]$EnValue,
    [string]$AzValue
)

$resBase = Join-Path $PSScriptRoot "..\Properties\Resources.resx"
$resAz = Join-Path $PSScriptRoot "..\Properties\Resources.az.resx"
$designer = Join-Path $PSScriptRoot "..\Properties\Resources.Designer.cs"

function Add-ToResx($file, $key, $value) {
    [xml]$xml = Get-Content $file -Encoding UTF8
    $node = $xml.root.data | Where-Object { $_.name -eq $key }
    if ($node) {
        $node.value = $value
    } else {
        $newNode = $xml.CreateElement("data")
        $newNode.SetAttribute("name", $key)
        $newNode.SetAttribute("xml:space", "preserve")
        $valNode = $xml.CreateElement("value")
        $valNode.InnerText = $value
        $newNode.AppendChild($valNode)
        $xml.root.AppendChild($newNode)
    }
    $xml.Save($file)
}

Add-ToResx $resBase $Key $EnValue
Add-ToResx $resAz $Key $AzValue

$designerContent = Get-Content $designer -Raw
if ($designerContent -notmatch "public static string $Key ") {
    $prop = @"
        
        /// <summary>
        ///   Looks up a localized string similar to $($EnValue -replace '"', '""').
        /// </summary>
        public static string $Key {
            get {
                return ResourceManager.GetString("$Key", resourceCulture);
            }
        }
"@
    $pos = $designerContent.LastIndexOf("}")
    $pos2 = $designerContent.LastIndexOf("}", $pos - 1)
    $newContent = $designerContent.Substring(0, $pos2) + $prop + "`r`n    }`r`n}`r`n"
    [System.IO.File]::WriteAllText($designer, $newContent, [System.Text.Encoding]::UTF8)
}
