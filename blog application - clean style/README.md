
# Clean Architecture README

## Overview

Clean Architecture is an architectural pattern utilized in software engineering essentially for the purpose of separting concerns and dependencies. It is also known as Onion architecture.

This README provides a summary of my understanding of clean architrecture.

## Key Principles

Clean Architecture is based on several fundamental principles:

1. **Separation of Concerns**: An application consists of different layers in general, such as the frameworks utilized, the database, external apis e.t.c . Layers like this can be grouped into categories such as infrastructure, core, api e.t.c
   
2. **Independence of Frameworks**: Clean Architecture aims to keep the core business logic of an application independent of any external frameworks or libraries. This makes the software more portable and less susceptible to changes in the technology stack.

3. **Testability**: The idea of separating concerns makes it easy to test individual components/layers without having to create complex mock during testing.

4. **Dependency Rule**: Dependency should point inwards towards the core application. The idea is that the main buisness logic should not tightly depend on any framework rather they should depend on it. This makes it easy to change dependencies.c

## Core Components

Clean Architecture typically consists of the following core components or layers:

1. **Entities**: Entities represent the core business objects or concepts. They are usually simple, domain-specific classes that encapsulate business rules and data.

2. **Interfaces**: Interfaces define the contract for interacting with external systems, such as databases, web services, or user interfaces. They abstract the details of these systems, making it easy to swap them out or test the application in isolation.

![image](https://github.com/johnnydanny/A2SV-Backend/assets/136840072/f186f136-1857-4a21-8100-e2889d20ec9b)


## Pros

  * Testability
  * Strict architecture—hard to make mistakes.
  * Business logic is encapsulated, easy to use, and tested.
  * Enforcement of dependencies through encapsulation.
  * Allows for parallel development.
  * Highly scalable.
  * Easy to understand and maintain.
  * Testing is facilitated.

## Cons
  * Although it's a good idea for big project, it can be overkill for simpler ones
  * Might cause performance issues
  * Increased complexity if not implemented well
  * Unnecessary abstractions might litter everywhere
