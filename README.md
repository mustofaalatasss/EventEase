# EventEase - Blazor Event Management Web Application

EventEase is a modern, responsive web application built with **Blazor WebAssembly** (.NET 8) designed to manage events, attendee registrations, and live check-in tracking. This project was developed following guided iterative activities utilizing **Microsoft Copilot** for code generation, debugging, performance optimization, and architectural enhancement.

---

## 🎯 Project Features & Grading Criteria Mapping

| Rubric Item / Requirement | Implementation Details | Location in Code |
| :--- | :--- | :--- |
| **1. GitHub Repository** | Public repository containing complete Blazor code and documentation. | Root repository |
| **2. Foundational Event Card & Two-Way Binding** | `EventCard.razor` displays event details and features an interactive inline edit mode utilizing Blazor two-way data binding (`@bind` and `@bind:event="oninput"`). | `Components/EventCard.razor` |
| **3. Routing Functionality & Debugging** | App routing implemented via `Router` with parameter routing (`/events/{Id:int}`), navigation links, and custom 404 fallback layout. | `App.razor`, `Pages/EventDetails.razor` |
| **4. Performance & Input Validation** | `EditForm` with `DataAnnotationsValidator` enforcing required fields, string length, regex telephone format, ticket limits, and terms check. Custom fallback prevents routing crashes. | `Models/RegistrationModel.cs`, `Pages/Register.razor` |
| **5. Advanced Features** | • **Registration Form**: Validated booking workflow.<br>• **State Management**: Scoped `EventSessionStateService` managing session state & real-time updates.<br>• **Attendance Tracker**: Live check-in/undo toggle and metrics. | `Pages/Register.razor`<br>`Services/EventSessionStateService.cs`<br>`Pages/AttendanceTracker.razor` |
| **6. Copilot Assistance Summary** | Detailed breakdown of Copilot prompts, code scaffolding, and fixes. | Documented below & in submission notes |

---

## 🤖 Summary of Microsoft Copilot Assistance Across Development Steps

### Activity 1: Generating Foundational Blazor Code
* **Component Scaffolding**: Copilot generated the initial layout for `EventCard.razor` along with model definitions (`EventItem.cs`).
* **Two-Way Data Binding**: Copilot suggested implementing `EventCallback<EventItem>` and inline edit controls binding directly to `Event.Title`, `Event.Location`, and `Event.Capacity` with real-time feedback using `@bind:event="oninput"`.

### Activity 2: Debugging and Performance Optimization
* **Routing Debugging**: Copilot identified missing route constraints for event detail pages and generated the `/events/{Id:int}` route along with null-safety checks when an invalid ID is requested.
* **NotFound Route Handling**: Copilot supplied a custom `NotFound` UI template in `App.razor` to gracefully capture broken URLs.
* **Input Validation**: Copilot configured `DataAnnotations` annotations (`[Required]`, `[EmailAddress]`, `[Range]`, `[Phone]`) on `RegistrationModel` and wired up `ValidationMessage` components to eliminate client-side errors and enhance form performance.

### Activity 3: Developing Advanced Features
* **Interactive Registration Form**: Copilot helped write `Pages/Register.razor` utilizing Blazor's `EditForm` component with automatic query string parameter parsing (`[SupplyParameterFromQuery]`).
* **Session State Management**: Copilot drafted `EventSessionStateService.cs` as a scoped singleton-like service with an `OnChange` event to broadcast state changes across independent components.
* **Attendance Tracker**: Copilot constructed `Pages/AttendanceTracker.razor`, delivering a reactive check-in dashboard with real-time attendee statistics, status filters, and toggle check-in buttons.

---

## 📁 Project Directory Structure

```text
EventEase/
├── Components/
│   └── EventCard.razor             # Foundational card with two-way data binding
├── Models/
│   ├── Attendee.cs                 # Attendee domain model
│   ├── EventItem.cs                # Event data model with capacity helpers
│   └── RegistrationModel.cs        # Form model with comprehensive DataAnnotations
├── Pages/
│   ├── AttendanceTracker.razor     # Live attendance management dashboard
│   ├── EventDetails.razor          # Parameterized routing page (/events/{id})
│   ├── Events.razor                # Events directory with search/filters
│   ├── Index.razor                 # Homepage dashboard & overview metrics
│   └── Register.razor              # Validated registration form
├── Services/
│   └── EventSessionStateService.cs # Centralized session & data state store
├── Shared/
│   ├── MainLayout.razor            # Responsive layout with header, active user session
│   └── NavMenu.razor               # Navigation menu links
├── wwwroot/
│   ├── css/app.css                 # Custom styling
│   └── index.html                  # WebAssembly entry point
├── App.razor                       # Blazor Router and 404 NotFound handler
├── EventEase.csproj                # Project definition
├── Program.cs                      # Dependency Injection & WebAssembly host
├── _Imports.razor                  # Global namespace imports
└── README.md                       # Documentation & submission review guide
```

---

## 🚀 How to Run Locally

### Prerequisites
* [.NET 8.0 SDK](https://dotnet.microsoft.com/download)

### Execution Steps
1. Clone this repository:
   ```bash
   git clone <YOUR_REPOSITORY_URL>
   cd EventEase
   ```
2. Restore packages and run the application:
   ```bash
   dotnet watch run
   ```
3. Open your browser and navigate to:
   ```text
   http://localhost:5000  or  https://localhost:5001
   ```
