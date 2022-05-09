# Clinic

System to manage medical clinic. It provides user with various functionality based on their role assigned by an administrator.

#### Table of Contents

 - [General info](#general-info)
 - [Images](#images)
 - [How to use](#how-to-use)
 - [Features for particular roles](#features-for-particular-roles)
 - [Technologies](#technologies)
 - [Status](#status)
 - [Links](#links)

### General info

The purpose of this application is to provide medical clinic with a complex system which allows to handle patient appointments and laboratory examinations.

### Images

<img src="https://user-images.githubusercontent.com/56251920/167429952-b0f4fdfa-2551-43f6-9dd6-6105cc842154.png" width="70%"/>

<img src="https://user-images.githubusercontent.com/56251920/167430136-0d5677e1-45be-4cd3-b5e8-bc390c642e5e.png" width="70%"/>

<img src="https://user-images.githubusercontent.com/56251920/167430183-66a44efe-4025-411d-a48a-2e84326df282.png" width="70%"/>

### How to use

To use the app perform following steps:

- ##### On localhost

  - Pull image from dockerhub https://hub.docker.com/repository/docker/marekkawalski/clinic
  - Run the container

- ##### From website

  - Go to website https://clinicsystemapp.azurewebsites.net

- Login to a particular account

  - Example credentials (login, password):
    - doctor: doctor@1.com, Password123!
    - registrar: registrar@registrar.com, Password123!
    - laboratory manager: labmanager@1.com, Password123!
    - lab technician: labtechnician@1.com, Password123!
    - admin: example access not granted

- Use the app!

### Features for particular roles

1. doctor:

   - View their appointments
   - Edit their appointments
   - View patients examination and appointments history
   - Order/edit laboratory examinations
   - Add/edit physical examinations

2. registrar:

   - Add/edit/search patients
   - Add/edit/view appointments

3. laboratory manager:

   - View/edit/search laboratory examinations

4. lab technician:

   - View/edit/search laboratory examinations

5. admin

   - Add new users
   - Select roles for user
   - Edit/enable/disable user accounts

### Technologies

- Asp .Net Core
- Entity Framework Core
- Blazor
- C#
- Html, css
- MsSQL
- Docker
- Azure
- Visual Studio

### Status

Development in progress

### Links

- website: https://clinicsystemapp.azurewebsites.net
- dockerhub repository: https://hub.docker.com/repository/docker/marekkawalski/clinic
