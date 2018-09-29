# Arhitecture

This api was built with the onion architecture. 
Onion architecture is a domain-centric architecure which provides a better way of building applications for better testability, maintainability, and dependability on the infrastructures like databases and services. This architecture's main aim is to provide a solution for common problems like coupling and separation of concerns.

There are three layers in the application. These layers are:

1. *Domain Layer* : The Domain Layer contains the entities and Repository Interfaces
2. *Infrastructure* : The infrastructure contains the Data Access Layer, Interface Implementation, IoC bindings and Migrations
3. *Web* : The web layer contains the Api end points

## Dependency Injection

In order to facilitate loose coupling, Dependency injection was used
Ninject was used as the IoC container for the Dependency injection

# Schemas
## Question
+ Id: Integer [Primary Key for the question table]
+ Text: String [Question Text]
+ Option: List [List  of options]
+ CategoryId: Intger [Foreign Key for category table]

## Category
+ Id: Integer [Primary Key for the category table]
+ Name: String [Category Name]

## Option
+ Id: Integer [Primary Key for the option table]
+ Text: String [Option Text]
+ QuestionId: Intger [Foreign Key for Question table]
+ IsCorrectOption: boolean [boolean value for whether the option is correct or not]

# End Points
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
