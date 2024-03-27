# Kanban

# This repository is in development for a class project, subject to change, and not fully functional. 
## Development, documentation, and setup instructions will not be completed until 4/30/2024. 
## These announcements will be removed when the project is ready. 
## Thank you for your interest and patience. 

 **Table of contents:**
 - [Purpose](#pur)
 - [Similar Software](#sim)
 - [Available Literature](#lit)
 - [Overview of Project Plan](#plan)
 - [Data Component of the project](#data)
 - [Simple Architecture Diagram](#arch)
 - [Wireframes](#wire)
 - [User Stories](#story)
 - [Use Cases](#case)
 - [UML Use Case Diagram](#uml)
 - [Requirements Table](#rt)
 - [ERD](#erd)
 - [UML Class Diagram](#class)
 - [Data Access Layer](#dal)
 <!-- headings -->
 
 <a id="pur"></a>
## Purpose
The purpose of a Kanban board is to visually manage tasks, limit work-in-progress, and improve the overall efficiency of a project. These boards are a common tool for agile and DevOps software development teams. However, the Kanban methodology is generalized and can be applied to almost any organizational workflow. My project for CIS4891 is a Kanban web application that is specifically aimed at solo/indie developers. The initial goal of this project is to build a minimum viable product that includes all the standard features of a kanban board. However, all parts of this project will be used as components of an application that is beyond the scope of this course. 
 <a id="sim"></a> 
## Similar Software and Products
There are many Kanban-style web applications available on the market. The most popular include Trello, Asana, and Jira. While these applications share many similarities, they have notable differences. Trello is extremely simple and ideal for small teams or individuals. Asana offers a wider range of features for larger teams and organizations but is more complex and may be overkill for smaller projects. Meanwhile, Jira differentiates itself by being designed specifically for software development teams.

<a id="lit"></a>
## Available Literature
There is an enormous amount of literature and documentation that will assist in the development of my project. 

**Blazor Documentation**
- https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-8.0

**Blazor's main website with videos, courses, and code examples.**
- https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor

**ASP.NET Core Documentation**
- https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0

**Azure App Service Documentation**
- https://learn.microsoft.com/en-us/azure/app-service/

**Azure SQL Documentation**
- https://learn.microsoft.com/en-us/azure/azure-sql/?view=azuresql

**Agile Project Management with Kanban | Eric Brechner | Talks at Google**
- https://www.youtube.com/watch?v=CD0y-aU1sXo


<a id="plan"></a>
## Overview of Project Plan
1.	**Inception:**
    - We started by investigating multiple project concepts and ideas that would fulfill the course project requirements. 
    - After analyzing the requirements and constraints of each option, we have picked one to build and created this specification document to outline its high-level functional requirements. 
3.	**Design:** 
    - We will set up a GitHub repository and are currently completing all the design documents. 
4.	**Development:** 
    - Build the Blazor Server Application 
    - Build the Azure SQL database 
    - Build the ASP.NET Core Web API.
    - Unit Testing
5. **Integration:**
    - Connect API to Database
    - Connect Blazor App to API
    - Integration testing.
6. **Deployment:**
    - Host the app, api, and database on my azure student account. 
    - Setup CI/CD for the app and api using different branches of my GitHub repository. 
8.	**QA:**
    - Exploratory Testing- by performing alpha and beta testing for bugs and real-world user experience. 
    - Acceptance Testing- Submit for grading.
10. **Closing:** 
    - Review the project and take notes about lessons learned throughout the project.
  
<a id="data"></a>
## Data Components
**Within the Blazor application:**
- The application's Data Access Layer (DAL) will request all of the user’s data from the REST API after the user has been successfully authenticated. Then, the API’s responses will be stored in a Data Access Object (DAO) which implements the IDataAccess interface. Once the DAO is instantiated, all other classes will have data access by either using or implementing the IDataAccess interface. 

**Within the API**
- All communication with the database is handled by the ASP.NET Core Web API.
- I used Entity Framework(EF) as my ORM within the API. This allowed a code-first approach to database design. I built the models and then EF helped create their controllers, schema definitions, database context, and performed the migration.

**Database:** 
- Currently using a generic local SQL database, but when hosted it will use AzureSQL.

## Conclusion
In conclusion, this will be a very simple Kanban-style web application. Its main components include a Blazor Server App, data access API, and database. The app will allow users to create, edit, and share Kanban boards online. Many similar products like Trello and Jira offer great inspiration for the UI layout as well as potential features. Since I will be using the .Net 8 stack to build a very common Kanban app, all the required documentation to complete this project is both widely available and free.

<a id="arch"></a>
## Architecture Diagram
![SAD](https://github.com/DonnellHarris/Kanban-2024/blob/master/Images/SAD.jpg)



<a id="wire"></a>
## Wireframe ( DRAFTS )
### Login page
This will be the first page the user sees when entering the site.\
The user must sign-in using a valid creditials to access the application.

![wireframe1](https://github.com/DonnellHarris/Kanban-2024/blob/master/Images/wireframe1.jpg)


### Browse boards
The authenticated user is shown a page containing all of their previously saved boards.\
The user can click on any board to open it.\
Alternatively, the user can click "Create" to start a new board.

![wireframe3](https://github.com/DonnellHarris/Kanban-2024/blob/master/Images/wireframe3.jpg)


### Kanban board
The user can add a new task/card, edit a card, reorder cards, and move cards between columns.\
The user can edit card titles, card descriptions, column labels, and card assignments.

![wireframe2](https://github.com/DonnellHarris/Kanban-2024/blob/master/Images/wireframe2.jpg)


<a id="story"></a>
## User Stories
1.	As a user, I need to sign-in to my account so that I can access the kanban application.
2.	As a user, I need to see all my saved boards so that I can choose one to view/edit.
3.	As a user, I need to create new columns and tasks so that I can visually manage my project.
4.	As a user, I need to move tasks between columns so that I can track task progression.
5.	As a user, I need to save my kanban board so that it can be opened later.

<a id="case"></a>
## Use-Cases

### 1. Use Case: Task Assignment and Progress Tracking
 **Title:** Assigning and Tracking Development Tasks\
 **Actors:**  Agile Development Team Members
 
 **Scenario:**\
 *Pre-existing Conditions:*
- The team has created a kanban board with columns: “To Do,” “In Progress,” and “Done.”
- Development tasks are listed as cards on the board.
  
 *Action Sequences:*
 1. The team identifies a new task, creates a card, and places it in the "To Do" column.
 2. The team assigns the task to a specific team member.
 3. The team member starts working on the task and moves the card to the “In Progress” column.
 4. As work progresses, the team member updates the card (e.g., adds notes, links).
 5.  When the task is complete, the team member moves the card to the “Done” column.
     
**Expected Result:** 
- The team can track task progress in real-time.
- Team members know their assigned tasks and collaborate effectively.
- Completed tasks are visible in the “Done” column.
  
### 2. Use Case: Bug Tracking and Resolution
  **Title:** Managing Software Defects\
  **Actors:** QA Team, Development Team
  
  **Scenario:**\
  *Pre-existing Conditions:*
  - The QA team has set up a Kanban board with columns: “New Bugs,” “In Review,” and “Resolved.”
  - Bugs are reported as cards on the board.
    
  *Action Sequences:*
  1. QA identifies a new bug, creates a card, and places it in the “New Bugs” column.
  2. Developers review the bug details, assign it to themselves, and move the card to the “In Review” column.
  3. Developers fix the bug, update the card, and move it to the “Resolved” column.
    
  **Expected Result:**
  - QA can track the status of reported bugs.
  - Developers efficiently address and resolve software defects.
    
### 3. Use Case: Content Creation Workflow
**Title:** Managing Content Production\
**Actors:** Content Team Lead, Writers, Editors

**Scenario:**\
*Pre-existing Conditions:*
- The content team lead has configured a Kanban board with columns: “Ideation,” “Writing,” “Editing,” and “Published.”
- Content pieces (articles, blog posts, etc.) are represented as cards.

*Action Sequences:*
1. Team lead identfies a new writing idea, creates a new card, and places it in the "Ideation" column.
2. Writers review the ideation cards, assign one or more to themselves, and place the card(s) in the "Writing" column while working.
3. When writing is complete, the card is moved to editing.
4. Editor reviews the draft, makes corrections, and moves it to “Published”.

**Expected Result:**
- The content team visualizes the content pipeline.
- Collaboration among team members streamlines content production.
  
### 4. Use Case: IT Operations Incident Management
**Title:** Handling IT Incidents \
**Actors:** IT Support Team, System Administrators

**Scenario:**\
*Pre-existing Conditions:*
- The IT support team has a Kanban board with columns: “Received,” “In Progress,” and “Resolved.”
- Incidents (server outages, software glitches) are represented as cards.
  
*Action Sequences:*
1. When an incident is reported, the support team creates a card and places it in the “Received” column.
2. Team members work on resolving the issue, update the card, and move it to “In Progress.”
3. Upon resolution, the card is moved to the “Resolved” column.
   
**Expected Result:**
- IT incidents are tracked systematically.
- Resources are allocated efficiently to address critical issues.
  
### 5. Use Case: Product Development Feature Requests
**Title:** Managing Feature Requests\
**Actors:** Product Manager, Development Team

**Scenario:**\
*Pre-existing Conditions:*
- The product manager has set up a Kanban board with columns: “Backlog", “Prioritized", “In Development", and "Done".
- Feature requests from stakeholders are represented as cards on the board.

*Action Sequences:*
1. Stakeholders submit feature requests, providing detailed descriptions and business justifications.
2. A card is created for each request and placed in "Backlog".
3. The product manager reviews "Backlog" and moves important feature cards to “Prioritized”.
4. The development team reviews "Prioritized", assigns cards, and place them "In Development".
5. As development progresses, team members update cards (e.g., attach design mockups, add technical details).
6. Once a feature is fully implemented, the card is moved to the “Done” column.

**Expected Result:**
- Stakeholders can track the status of their requested features.
- The development team efficiently delivers valuable enhancements to the product.

<a id="uml"></a>
## Use-Case Diagram
![use case diagram](https://github.com/DonnellHarris/Kanban-2024/blob/master/Images/use%20case%20diagram.jpg)


<a id="rt"></a>
## Requirements Table
| Id | Requirement                                    |
|:---|                                            ---:|
| 11 | "Register Page" shall allow users to register.                  |
| 12 | "Login Page" shall allow users to login.                    |
| 21 | "+Board Button" shall allow users to create a Kanban board.    |
| 22 | "My Boards Page" shall allow users to open a Kanban board.      |
| 23 | "Save Button" shall allow users to save a Kanban board.      |
| 24 | "Delete Button" shall allow users to delete a Kanban board.    |
| 31 | "+List Button" shall allow users to add lists to a board.     |
| 32 | "Drag-n-Drop functionality" shall allow users to move/reorder the lists.   |
| 33 | "Rename Button" shall open the rename dialog and allow users to rename a list.            |
| 34 | "Delete List Button" shall allow users to delete a list.            |
| 41 | "+Task Button" shall allow users to add a task to a list.      |
| 42 | "Drag-n-drop functionality" shall allow users to move a task between lists. |
| 43 | "Drag-n-drop functionality" shall allow users to reorder tasks on a list.  |
| 44 | "Edit Task Button" shall open the edit task dialog and allow users to update a task.            |
| 45 | "Delete Task Button" shall allow users to delete a task.            |

<a id="erd"></a>
## ERD
![ERD](https://github.com/DonnellHarris/Kanban-2024/blob/master/Images/ERD.jpg)



<a id="class"></a>
## Blazor App UML Class Diagram
![ClassDiagram](https://github.com/DonnellHarris/Kanban-2024/blob/master/Images/newClassDiagram.jpg)

<a id="dal"></a>

## Data Access Layer

**Models Code Screenshots**

- UserModel

![UserModel](https://github.com/DonnellHarris/Kanban-2024/blob/master/Images/UserModel.png)

- WorkspaceModel

![WorkspaceModel](https://github.com/DonnellHarris/Kanban-2024/blob/master/Images/WorkspaceModel.png)

- BoardModel

![BoardModel](https://github.com/DonnellHarris/Kanban-2024/blob/master/Images/BoardModel.png)

- ColumnModel

![ColumnModel](https://github.com/DonnellHarris/Kanban-2024/blob/master/Images/ColumnModel.png)

- TaskModel

![TaskModel](https://github.com/DonnellHarris/Kanban-2024/blob/master/Images/TaskModel.png)


**Getting a user by UserId**
![GetData](https://github.com/DonnellHarris/Kanban-2024/blob/master/Images/GetData.png)





