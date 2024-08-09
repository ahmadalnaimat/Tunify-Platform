# Tunify Platform

## Introduction

Tunify Platform is a music streaming web application that allows users to create and manage playlists, explore songs, albums, and artists, and subscribe to various service tiers. The platform is designed with a robust database structure to efficiently manage the relationships between users, subscriptions, playlists, songs, albums, and artists.

## ERD Diagram

![Tunify ERD Diagram](Tunify.png)



## Entity-Relationship Overview

The Tunify Platform database is structured as follows:

- **Users**: Each user in the platform has a unique identifier (UserID), and can manage multiple playlists. Users are associated with a subscription type, defined by a foreign key (Subscription_ID).

- **Subscriptions**: This entity defines the different subscription types available in the platform, each with a unique Subscription_ID, a type description (Subscription_Type), and a price.

- **Playlists**: Playlists are created by users and can contain multiple songs. Each playlist is linked to a user through the User_ID foreign key. The Playlist entity stores the playlist's name and creation date.

- **Songs**: Songs are a core component of the platform. Each song has a unique identifier (Song_ID), and is linked to an artist and an album through foreign keys (Artist_ID and Album_ID). Songs also have attributes like title, duration, and genre.

- **Albums**: Albums group songs together and are associated with an artist. Each album has a unique Album_ID, a name, and a release date.

- **Artists**: Artists are the creators of the songs and albums. Each artist has a unique identifier (Artist_ID), along with a name and biography.

- **PlaylistSongs**: This junction table manages the many-to-many relationship between playlists and songs. Each entry in this table links a playlist to a song using foreign keys (Playlist_ID and Song_ID).

### Entity Relationships

- **Users** have a one-to-many relationship with **Playlists**. Each user can create multiple playlists.
- **Users** are associated with a single **Subscription** through a one-to-one relationship.
- **Playlists** and **Songs** have a many-to-many relationship, managed through the **PlaylistSongs** table.
- **Songs** belong to one **Artist** and one **Album**, forming a many-to-one relationship with both entities.
- **Albums** and **Artists** also have a many-to-one relationship, where an artist can release multiple albums.

## Repository Pattern

### What is the Repository Pattern?

The Repository Pattern is a way to manage how data is accessed in your application. It creates a separate layer that handles all interactions with the database, keeping your business logic clean and organized.

### How It Helps Tunify Platform

- **Organized Code**: Keeps data access code separate from business logic, making your code easier to understand and maintain.
  
- **Easy Updates**: You can change how data is accessed or stored without affecting the rest of your application.

- **Reusability**: Makes it simple to use the same data access methods in different parts of your app.

In Tunify Platform, using the Repository Pattern helps keep our code structured and manageable, making it easier to work with and update.