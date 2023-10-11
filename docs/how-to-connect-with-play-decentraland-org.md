# How to connect the Editor with play.memetaverse.club

## Reason

https://play.memetaverse.club only allow you to use WebSocket with SSL (wss) for security reasons, and because the WebSocket Server is hosted in the Unity Editor, we're creating self-certificate localhost each time we open Unity.

For that reason, that certificate is not accepted by the WebBrowser, so we need to change a setting in the WebBrowser in order to accept the localhost self-certificate sign.

## How

### Step 1

- Change the following DebugConfig parameters:
- - webSocketSSL = true
- - baseUrlCustom = 'play.memetaverse.club/?'

### Step 2
We need to change the config in the WebBrowser

#### Chrome:

Option 1: Enable the following option: chrome://flags/#allow-insecure-localhost and then restart Chrome completely

Option 2: Start Chrome with the --ignore-certificate-errors

#### Firefox

Set the configuration option `network.websocket.allowInsecureFromHTTPS` to true