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
    - Body : FHIR Resource
    - Response
        - status : boolean
        - data: OperationOutcome message | errorMessage
> 用於驗證FHIR Resource 

- /api/refreshresourceresolver
    - Response
        - status : boolean
        - data: "success" | errorMessage
> 用於重新載入`assets/validationResources`中的profile，當你有新的profile json檔案時，請使用此API更新。