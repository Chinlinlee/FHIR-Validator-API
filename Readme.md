# FHIR-Validator-API
Currently implementation of the validation with javascript is not complete, so the SDK provided by C# Firely to implement the validation function as solution will be used in [Burni](https://github.com/Chinlinlee/Burni) to achieve the function of $validator API. 

[繁體中文 readme](Readme_zh_TW.md)

## Dependencies
- [firely-net-sdk R4 version](https://github.com/FirelyTeam/firely-net-sdk)


## Usage
### FHIR Profiles
Put the profile json file in `assets/validationResources` that you want to validate.

### API
- /api/validate
> The API validate FHIR Resource 
<table>
<tr>
    <td>Name</td>
    <td>Value</td>
    <td>Description</td>
</tr>
<tr>
<td>method</td>
<td>POST</td>
<td>The HTTP method</td>
</tr>
<tr>
<td>
    request body
</td>
<td>

```json
{
    "profile": [
        "profile-array-string"
    ],
    "resourceJson": "FHIR resource JSON string"
}
```

</td>
<td>
    The request body use JSON
</td>
</tr>
<tr>
    <td>
        response
    </td>
<td>

```json
{
    "status": true,
    "data": "OperationOutcome || error message"
}
```

</td>
<td>status: false when server throw error</td>
    </tr>
</table>

- /api/refreshresourceresolver
> The API reload the profiles in `assets/validationResources`, please use this API to update when you have a new profile store in folder.

<table>
<tr>
    <td>Name</td>
    <td>Value</td>
    <td>Description</td>
</tr>
<tr>
<td>method</td>
<td>POST</td>
<td>The HTTP method</td>
</tr>
<tr>
<td>request body</td>
<td>None</td>
<td>None</td>
</tr>
<tr>
<td>response</td>
<td>

```json
{
    "status": true,
    "data": "\"success\" || errorMessage"
}
```

</td>
<td>status: false when server throw error. <br />
data: "success" or errorMessage
</td>
</tr>
</table>