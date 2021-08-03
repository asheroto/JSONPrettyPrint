Imports System.Runtime.InteropServices
Imports Newtonsoft.Json

Module Program

    Sub Main(args As String())
        Dim data As String = Nothing

        Dim consoleData As String = Nothing
        Dim isKeyAvailable As Boolean
        Try
            isKeyAvailable = Console.KeyAvailable
        Catch expected As InvalidOperationException
            consoleData = Console.In.ReadToEnd()
        End Try

        If consoleData <> Nothing Then
            'If data is piped
            data = consoleData
        Else
            'If data is not piped
            WriteHelp()
        End If

        'Format JSON
        Dim json As String = Nothing
        Dim result As String = Nothing
        Try
            result = format_json(data)
        Catch ex As Exception
            Console.WriteLine(String.Format("Could not detect JSON data."))
            End
        End Try

        'Write output
        result = result.Trim
        Console.Write(result)
    End Sub

    Function format_json(ByVal json As String) As String
        Dim parsedJson As Object = JsonConvert.DeserializeObject(json)
        Return JsonConvert.SerializeObject(parsedJson, Formatting.Indented)
    End Function

    Function GetOS() As String
        Dim OS As String = Nothing

        If RuntimeInformation.IsOSPlatform(OSPlatform.Windows) Then
            OS = "Windows"
        ElseIf RuntimeInformation.IsOSPlatform(OSPlatform.Linux) Then
            OS = "Linux"
        ElseIf RuntimeInformation.IsOSPlatform(OSPlatform.OSX) Then
            OS = "OSX"
        End If

        Return OS

    End Function
    Sub WriteHelp()
        Console.WriteLine()
        Console.WriteLine("Pipe JSON data to JSONPrettyPrint and it will become pretty!")
        Console.WriteLine()
        Console.WriteLine("Example:")
        If GetOS() = "Windows" Then
            Console.WriteLine("     $(Invoke-WebRequest https://am.i.mullvad.net/json).Content | .\JSONPrettyPrint.exe")
            Console.WriteLine()
            Console.WriteLine("         or if curl.exe is installed...")
            Console.WriteLine()
            Console.WriteLine("     curl.exe -s https://am.i.mullvad.net/json | .\JSONPrettyPrint.exe")
        Else
            Console.WriteLine("     curl -s https://am.i.mullvad.net/json | ./JSONPrettyPrint")
        End If
        Console.WriteLine()
        End
    End Sub

End Module