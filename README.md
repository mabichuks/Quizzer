# Quizzer
This is a quiz application web api with ASP.NET
## Open Endpoints

Open endpoints require no Authentication.

### Login

Cookie based Authentication

**URL** : `/api/account/login/`

**Method** : `POST`

**Auth required** : NO

**Data constraints**

```json
{
    "username": "[valid email address]",
    "password": "[password in plain text]"
}
```

**Data example**

```json
{
    "username": "chuks@gmail.com",
    "password": "passw0rd"
}
```

#### Success Response

**Code** : `202 ACCEPTED`

**Content example**

```json
{
    "Successfully Signed In"
}
```

#### Error Response

**Condition** : If 'username' and 'password' combination is wrong.

**Code** : `404 NOT FOUND`

**Content** :

```json
{
   
        "User Not Found"
    
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


### Login

Used to register a user

**URL** : `/api/account/register/`

**Method** : `POST`

**Auth required** : NO

**Data constraints**

```json
{
    "username": "[valid email address]",
    "password": "[password in plain text]"
    "confirmpassword": "[should be the same value entered in password field]"
    "ImageUrl": "[Url path of profile picture]"
}
```

**Data example**

```json
{
    "username": "chuks@gmail.com",
    "password": "passw0rd"
    "confirmpassword": "passw0rd"
    "imageurl": "**/content/images/picture.jpg"
}
```

#### Success Response

**Code** : `202 ACCEPTED`

**Content example**

```json
{
    "Successfully Registered"
}
```

#### Error Response

**Condition** : If email has already been registered.

**Code** : `400 BAD REQUEST`

**Content** :

```json
{
   
        "User already exists"
    
}
```
**Condition** : If input fields are not valid.

**Code** : `400 BAD REQUEST`

**Content** :

```json
{
   
        "Invalid fields"
    
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

## Endpoints that require Authentication

Closed endpoints user to be authenticated. A user can be authenticated by signing up and logging in

### Get Questions

Gets all questions from all categories

**URL** : `/api/quiz/getquestions`

**Method** : `GET`

**Auth required** : YES

#### Success Response

**Code** : `200 OK`

**Content examples**


```json
  {
    "Category": {
      "Id": 1,
      "Name": "Math"
    },
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
### Get Categories

Gets all the categories of questions

**URL** : `/api/quiz/getcategories`

**Method** : `GET`

**Auth required** : YES

#### Success Response

**Code** : `200 OK`

**Content examples**


```json
  {
    "Id": 1,
    "Name": "Math"
  },
  {
    "Id": 2,
    "Name": "English"
  },
```
**Condition** : No internet connection, Server error, etc.

**Code** : `500 INTERNAL SERVER ERROR`

**Content** :

```json
{
    
        "Exception Message"
    
}
```

### Get Correct answer

Gets the correct answer of a specified question 

**URL** : `/api/quiz/getcorrectanswer/{questionId}`

**Method** : `GET`

**Auth required** : YES

#### Success Response

**Code** : `200 OK`

**Content examples**


```json
"5"
```
**Condition** : No internet connection, Server error, etc.

**Code** : `500 INTERNAL SERVER ERROR`

**Content** :

```json
{
    
        "Exception Message"
    
}
```

### Get Question By Category

Gets the a list of questions by the category that was specified

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
