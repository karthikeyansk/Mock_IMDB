# Mock_IMDB
     This project mocks the behaviour of the imdb website api endpoints.Actors,Movies,
     Producers are the entities used in this project.Below are list of available endpoints 
      
# Database Design 
  ![dbdesign](https://user-images.githubusercontent.com/31660056/141492563-f862f89b-765e-4c59-b6ef-29114a18c93f.png)
# Tables
  *  Movie-Holds all movie details
  *  Actor-Holds actor details
  *  Producers-Hold producer details
  *  MovieCast- Mapping table between movie and actors.Since movie and actors have many-many relationship

# Enpoints Description
HTTP Verb|Route | What really does
---|--- | --- 
GET|/api/movie | List all movies
GET|/api/movie/{id}| Get the movie with specified id
POST|/api/movie/{id}| update the movie with given id in route
POST|/api/movie|Adds a new Movie
POST|/api/actor|Adds a new actor
GET|/api/actor|List all actors
POST|/api/producer|Adds a new Producer
GET|/api/producer|List all Producer

## Sample Reponses
### Add Movie
![AddMovie](https://user-images.githubusercontent.com/31660056/141490745-967c2d5a-722a-48d8-a6d8-d916b953e17b.png)

### Get Movies

![GetMovies](https://user-images.githubusercontent.com/31660056/141490882-6189ad70-d622-4e73-8dbb-f1968287f07c.png)

### Update Movies

![UpdateMovie_1](https://user-images.githubusercontent.com/31660056/141491013-530094f1-1966-475f-a1a0-40fd120cd522.png)
### before update
![MovieUpdate_Before](https://user-images.githubusercontent.com/31660056/141491019-4f47f5f2-45f7-41d4-bd8f-0d634e3da568.png)
### after update
![MovieUpdate_After](https://user-images.githubusercontent.com/31660056/141491016-1cf756a5-91fe-412d-b660-de0bf5fcfced.png)

### Add actor
![AddActor](https://user-images.githubusercontent.com/31660056/141491344-d0bf63df-0af8-44a4-9758-18a3b3d4ae37.png)
### List actors
![GetActors](https://user-images.githubusercontent.com/31660056/141491475-1377adf9-0763-4368-8a1e-6b139aeed448.png)

### Add Producer
![AddProducer](https://user-images.githubusercontent.com/31660056/141491518-b35efeb4-13b4-44d1-89b9-cc5ea07cbf45.png)
### List Producer
![GetProducers](https://user-images.githubusercontent.com/31660056/141491600-5a6aab46-b904-4e5b-bf0a-9ea5cfdcdc71.png)
