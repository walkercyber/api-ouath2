### Solar OAuth2 API & Web App

This project consists of two components:

1. **WebApi** – an ASP.NET Core minimal API that handles the **OAuth 2.0 authorization flow**, exchanging authorization codes for access tokens.  
2. **WebApp** – a simplified Blazor web client that redirects the user to an OAuth2 provider and communicates with the API to complete authentication.

---

#### Purpose

The goal of this project is to:
- Authenticate users using the **OAuth 2.0 Authorization Code Flow**
- Exchange the received authorization `code` for an **access token**
- Enable the web client to use that access token when accessing protected resources through the API
