# FHIR-Validator-API
目前javascript在實現驗證功能的opensource還並不完整，所以採用C# Firely所提供的SDK實作驗證功能作為解決方案，並將與[Burni](https://github.com/Chinlinlee/Burni)整合使用，以實現$validator API的功能。

[English readme](Readme.md)

## Dependencies
- [firely-net-sdk R4 version](https://github.com/FirelyTeam/firely-net-sdk)


## Usage
### FHIR Profiles
將想要檢查的profile放置到`assets/validationResources`中。

### API
- /api/validate
> 用於驗證FHIR Resource 
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
> 用於重新載入`assets/validationResources`中的profile，當你有新的profile json檔案時，請使用此API更新。

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

### Docker 相關資訊
<table>
    <tr>
        <td>Name</td>
        <td>Description</td>
    </tr>
    <tr>
        <td>PORT</td>
        <td>7414</td>
    </tr>
</table>
