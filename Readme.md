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
    - Body : FHIR Resource
    - Response
        - status : boolean
        - data: OperationOutcome message | errorMessage
> The API validate FHIR Resource 

- /api/refreshresourceresolver
    - Response
        - status : boolean
        - data: "success" | errorMessage
> The API reload the profiles in `assets/validationResources`, please use this API to update when you have a new profile store in folder.