
# JSONPrettyPrint
Pipe JSON data to make it pretty!

Works on Windows, Linux, Mac.

# Example Usage

To output to file, specify `-o <file>` or `--output <file>`.

## Windows

`$(Invoke-WebRequest https://am.i.mullvad.net/json).Content | JSONPrettyPrint`

or if `curl.exe` is installed...

`curl -s https://am.i.mullvad.net/json | JSONPrettyPrint`

## Linux/Mac
`curl -s https://am.i.mullvad.net/json | JSONPrettyPrint`

# Download & Run

## Windows

**win-x64:**

[Download JSONPrettyPrint_win-x64.exe](<https://github.com/asheroto/JSONPrettyPrint/releases/latest/download/JSONPrettyPrint_win-x64.exe>), then run or open `JSONPrettyPrint_win-x64.exe`

**win-x86:**

[Download JSONPrettyPrint_win-x86.exe](<https://github.com/asheroto/JSONPrettyPrint/releases/latest/download/JSONPrettyPrint_win-x86.exe>), then run or open `JSONPrettyPrint_win-x86.exe`

**win-arm64:**

[Download JSONPrettyPrint_win-arm64.exe](<https://github.com/asheroto/JSONPrettyPrint/releases/latest/download/JSONPrettyPrint_win-arm64.exe>), then run or open `JSONPrettyPrint_win-arm64.exe`

## Linux

**linux-64:**
```
wget https://github.com/asheroto/JSONPrettyPrint/releases/latest/download/JSONPrettyPrint_linux-x64
chmod +x JSONPrettyPrint_linux-x64
./JSONPrettyPrint_linux-x64
```

**linux-arm:**
```
wget https://github.com/asheroto/JSONPrettyPrint/releases/latest/download/JSONPrettyPrint_linux-arm
chmod +x JSONPrettyPrint_linux-arm
./JSONPrettyPrint_linux-arm
```

**linux-arm64:**
```
wget https://github.com/asheroto/JSONPrettyPrint/releases/latest/download/JSONPrettyPrint_linux-arm64
chmod +x JSONPrettyPrint_linux-arm64
./JSONPrettyPrint_linux-arm64
```

### Mac

**osx-x64:**
```
wget https://github.com/asheroto/JSONPrettyPrint/releases/latest/download/JSONPrettyPrint_osx-x64
chmod +x JSONPrettyPrint_osx-x64
./JSONPrettyPrint_osx-x64
```
