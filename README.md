
## OAuth2 API & Web App — SMA Data Integration

This solution contains two main components:

### WebApi
An **ASP.NET Core Minimal API** that handles the **OAuth 2.0 Authorization Code Flow**.  

### WebApp
A simplyfied **Blazor WebApp** that starts the OAuth2 login process.  
It redirects the user to the **SMA authorization page**, receives the authorization code, and communicates with the API to retrieve and store the access token.

---

## The goal of this project is to:

- Authenticate users securely using **OAuth 2.0 Authorization Code Flow**  
- Exchange the received **authorization code** for an **access token**  
- Allow the Blazor client to use that token when calling **protected SMA API resources**  
- Provide a working example of integrating with the **SMA Developer API** for real data retrieval  

---

## How It Works

1. The user clicks the **Login** button in the Blazor app.  
2. The app redirects the browser to the **SMA OAuth2 authorization endpoint**.  
3. After successful login, SMA redirects back with an **authorization code**.  
4. The **WebApi** exchanges that code for an **access token** using the token endpoint.  
5. The **WebApp** then uses the access token to call protected endpoints
   
This implementation follows the **Authorization Code Grant Flow**, which is the recommended and most secure OAuth2 pattern for web applications.

## OAuth2 Flow Diagram

```text
 ┌────────────┐          ┌────────────────┐          ┌──────────────┐
 │  Web App   │          │  SMA Auth API  │          │   Web API    │
 └─────┬──────┘          └──────┬─────────┘          └──────┬──────┘
       │ (1) Login → Redirect   │                           │
       ├────────────────────────>                           │
       │                         │                          │
       │   (2) User Authorizes   │                          │
       │<────────────────────────│                          │
       │                         │                          │
       │   (3) Returns Code      │                          │
       │<────────────────────────│                          │
       │                         │                          │
       │   (4) Sends Code        │                          │
       ├────────────────────────────────────────────────────>│
       │                         │                          │
       │                         │  (5) API Requests Token  │
       │                         ├──────────────────────────>│
       │                         │                          │
       │                         │   (6) Returns AccessToken│
       │                         │<──────────────────────────│
       │                         │                          │
       │   (7) WebApp Uses Token │                          │
       └────────────────────────────────────────────────────>│

