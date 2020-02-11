# fakeserver

## Endpoints
fakeserver.westus.azurecontainer.io

fakeserverindia.southindia.azurecontainer.io

fakeserverweu.westeurope.azurecontainer.io

## Configure fake server

### Configure GET method

```
PUT http://fakeserver.westus.azurecontainer.io/register/<Unique GUID>/<Your application Path>?method=GET

{
	"mycontent": "mycontentvaluehttpdd"
}

```

#### Example

```
PUT http://fakeserver.westus.azurecontainer.io/register/228756a0-46bb-4280-b69a-ab5a95b09a82/mypath123?method=GET

{
	"mycontent": "mycontentvaluehttpdd"
}

```

### Configure PUT method

```
PUT http://fakeserver.westus.azurecontainer.io/register/<Unique GUID>/<Your application Path>?method=PUT

{
	"mycontent": "mycontentvalue"
}

```

#### Example

```
PUT http://fakeserver.westus.azurecontainer.io/register/228756a0-46bb-4280-b69a-ab5a95b09a82/mypath123?method=PUT

{
	"mycontent": "mycontentvalue"
}

```

### Configure POST method

```
PUT http://fakeserver.westus.azurecontainer.io/register/<Unique GUID>/<Your application Path>?method=POST

{
	"mycontent": "mycontentvalue"
}

```

#### Example

```
PUT http://fakeserver.westus.azurecontainer.io/register/228756a0-46bb-4280-b69a-ab5a95b09a82/mypath123?method=POST

{
	"mycontent": "mycontentvalue"
}

```

## Call Fake server

### Use PUT method

```
PUT http://fakeserver.westus.azurecontainer.io/server/<Unique GUID>/<Your application Path>

{
	"mycontent": "mycontentvalue",
    "modifiedContent": "modifiedContentValue"
}

```

#### Example

```
PUT http://fakeserver.westus.azurecontainer.io/server/228756a0-46bb-4280-b69a-ab5a95b09a82/mypath123

{
	"mycontent": "mycontentvalue"
}

```

### Use GET method

```
GET http://fakeserver.westus.azurecontainer.io/server/<Unique GUID>/<Your application Path>

```

#### Example

```
GET http://fakeserver.westus.azurecontainer.io/server/228756a0-46bb-4280-b69a-ab5a95b09a82/mypath123


##### Response
{
	"mycontent": "mycontentvalue"
}

```

### Limitations

Since data is currently stored in memory and server is configured to restart when memory exceeds a certain limit, assume server configuration to be volatile in long duration (range of weeks depending on load).

Primary use case is to support test-driven development of client without the need of the server.

### Security
Its http right now and data is not secured. Make sure that secret is not part of the body.