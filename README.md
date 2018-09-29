# Quizzer
This is a quiz application web api with ASP.NET
## Open Endpoints

Open endpoints require no Authentication.

### Login

Cookie based Authentication

**URL** : `/api/account/login/`

**Method** : `POST`


**URL** : `/api/account/register/`

**Method** : `POST`



**URL** : `/api/quiz/getquestions`

**Method** : `GET`


**URL** : `/api/quiz/getcategories`

**Method** : `GET`

**URL** : `/api/quiz/getcorrectanswer/{questionId}`

**Method** : `GET`


**URL** : `/api/quiz/getquestionbycategory/{categoryId}`

**Method** : `GET`

**Auth required** : YES

#### Success Response

**Code** : `200 OK`

**Content examples**


```json
 {
    "Id": 1,
    "Text": "Square root of 25",
    "CategoryId": 1,
    "Options": [
      {
        "Id": 1,
        "Text": "3",
        "QuestionId": 1,
        "IsCorrectOption": false
      },
      {
        "Id": 2,
        "Text": "4",
        "QuestionId": 1,
        "IsCorrectOption": false
      },
      {
        "Id": 3,
        "Text": "5",
        "QuestionId": 1,
        "IsCorrectOption": true
      }
    ]
  }
  ```
**Condition** : No internet connection, Server error, etc.

**Code** : `500 INTERNAL SERVER ERROR`

**Content** :

```json
{
    
        "Exception Message"
    
}
```
