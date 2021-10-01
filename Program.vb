Imports System.Runtime.InteropServices
Imports Newtonsoft.Json

Module Program
    Sub Main(args As String())
        Dim data As String = Nothing
        Dim fileName As String = Nothing

        If args.Count = 2 Then
            If LCase(args(0)) = "-o" Or LCase(args(0)) = "--output" Then
                fileName = args(1)
            End If
        End If

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

        result = result.Trim
        If fileName IsNot Nothing Then
            'Write output to file
            Try
                IO.File.WriteAllText(fileName, result)
                Console.WriteLine("Contents saved to: " & fileName)
            Catch ex As Exception
                Console.WriteLine("Error: " & ex.Message)
            End Try
        Else
            'Write output to screen
            Console.Write(result)
        End If
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
        Console.WriteLine("Optionally output to file:")
        Console.WriteLine("     -o <file>")
        Console.WriteLine("     --output <file>")
        Console.WriteLine()
        Console.WriteLine("Example:")
        If GetOS() = "Windows" Then
            Console.WriteLine("     $(Invoke-WebRequest https://am.i.mullvad.net/json).Content | JSONPrettyPrint")
            Console.WriteLine()
            Console.WriteLine("         or if curl.exe is installed...")
            Console.WriteLine()
            Console.WriteLine("     curl.exe -s https://am.i.mullvad.net/json | JSONPrettyPrint")
        Else
            Console.WriteLine("     curl -s https://am.i.mullvad.net/json | JSONPrettyPrint")
        End If
        Console.WriteLine()
        End
    End Sub

End Module