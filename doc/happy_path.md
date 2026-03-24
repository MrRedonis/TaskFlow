# Przypisanie zadań użytkownikowi

## Endpoint
POST /api/Users/{userId}/issues

### Parametr

userId - aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa

### Request Body

```json
{
  "issueIds": [
    "8f4526f7-f85d-47a7-8ab2-9e5fabe19348",
    "1cf4c968-ea6a-48f2-aac7-e62496ec44b7",
    "329bf437-b4ba-43af-b8d5-db54c81b5096",
    "220ffec1-85d9-4fea-be3d-709e5ae93d44",
    "7acfee96-f380-4fc0-990b-ed0198f34de2",
    "75a4f286-34d6-462a-bd50-46688fc6eab4",
    "935d0f71-ca19-4074-9bcb-7ee949fb7118",
    "bbc1392e-7149-40ae-abd7-931798f8ab79"
  ]
}
