This project is specifically for Assessment purpose. 
The backedn of this project is build in .net6.0 and front end is built in angular 13 along with postgres database


How to run the Project
.net core service is developed in .net 6.0. So, to run the service, you should have vs2022. just download the project and run it on local. 
I have set the application to run on specific port on localhost. 
service link needs to be added in environment.ts file in angular project. 
if it runs on different port then you need to change environment variable of FE project to make sure about connectivity between FE and BE.

No sharing code used at this moment but their is scope for improvement of this application.

Angular UI is pathetic at the moment as designing takes lot of time. but i can improve UI if i get enough time :)

Regarding Backend .net core service
clean architecture is used for the project which includes API, application, domain and infrasturcture layer.
use of entity framework
repository pattern, unit of work (generally it is not recommended when you use entity framework but due to limited time contraint i used that)
CQRS pattern for keeping read and write responsibility seperation
Automapper has been used for model mapping.

pending part
entity framework is not used properly. Need some refactoring on that part
need to add support for SQL server, it would be single line change
unit tests for services
supporting scripts for MS SQL needs to be added. postgres one are already shared.

Additions
in .net core service, you might see additional step between API and application layer communication. that can be removed but i wanted to add GRPC support so i kept for that now.
in short, when GRPC support is being added in application (separate API portion only) then other 3 layers (application, domain, infrasturcture) can be used for both API project
(API project which will support json and grpc)
opentelemetry/prometheus support can be added for measuring metrics
once opentelemetry is configured, it can be mapped with grafana


Regarding angular project
completed part
Insert update delete operations are completed for admin
admin can browse product and rate them.
Admin can see list of products in tabular format and can perform CRUD operation from there only
End user can see only list of products
Lazy loading and angular routing has been used and correctly mapped but there was one point peding to pass data between components due to time constrain. So for now, permissions are handled hardcodedly.
proper structure has been used. Like seperation of admin and user section, seperation of shared components and seperation of modules as well which is properly mapped

pending part
couldn't used material UI fully due to time constraint
authguard can be used
stores needs to be used wherever required

Additions
grpc support can be added

