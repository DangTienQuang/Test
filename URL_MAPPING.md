# API URL Mapping Guide for Frontend

This document outlines the RESTful URL changes made to standardize the API routing. Please use global search and replace to update these endpoints in the Frontend codebase.

## 1. Authentication (`AuthController`)
* Base Route: `api/auth`
| Action | Old URL | New URL | HTTP Method |
| :--- | :--- | :--- | :--- |
| Register | `/api/AuthController/register` (or `api/authcontroller/register`) | `/api/auth/register` | POST |
| Login | `/api/AuthController/login` (or `api/authcontroller/login`) | `/api/auth/login` | POST |

## 2. User Management (`UserController`)
* Base Route: `api/users`
| Action | Old URL | New URL | HTTP Method |
| :--- | :--- | :--- | :--- |
| Get My Profile | `/api/UserController/profile` | `/api/users/me` | GET |
| Update Profile | `/api/UserController/profile` | `/api/users/me` | PUT |
| Upload Avatar | `/api/UserController/upload-avatar` | `/api/users/me/avatar` | POST |
| Update Payment | `/api/UserController/payment` | `/api/users/me/payment` | PUT |
| Change Password| `/api/UserController/change-password` | `/api/users/me/password` | POST |
| Import Users | `/api/UserController/import` | `/api/users/import` | POST |
| Get All Users | `/api/UserController` | `/api/users` | GET |
| Create User | `/api/UserController` | `/api/users` | POST |
| Update User | `/api/UserController/{id}` | `/api/users/{id}` | PUT |
| Toggle Status | `/api/UserController/{id}/status` | `/api/users/{id}/status` | PATCH |
| Delete User | `/api/UserController/{id}` | `/api/users/{id}` | DELETE |

## 3. Project Management
* Base Route: `api/projects`
| Action | Old URL | New URL | HTTP Method | Note |
| :--- | :--- | :--- | :--- | :--- |
| Create Project | `/api/Project` | `/api/projects` | POST |
| Update Project | `/api/Project/{id}` | `/api/projects/{id}` | PUT |
| Get Project | `/api/Project/{id}` | `/api/projects/{id}` | GET |
| Get by Manager | `/api/Project/manager/{managerId}` | `/api/projects/manager/{managerId}` | GET |
| Delete Project | `/api/Project/{id}` | `/api/projects/{id}` | DELETE |
| Import Data | `/api/ProjectData/{projectId}/import` | `/api/projects/{projectId}/import` | POST |
| Upload Direct | `/api/ProjectData/{projectId}/upload-direct` | `/api/projects/{projectId}/upload-direct` | POST |
| Get Buckets | `/api/ProjectData/{projectId}/buckets` | `/api/projects/{projectId}/buckets` | GET |
| Export Data | `/api/ProjectData/{projectId}/export` | `/api/projects/{projectId}/export` | GET |
| Gen Invoices | `/api/ProjectFinance/{projectId}/generate-invoice` | `/api/projects/{projectId}/invoices` | POST | Removed verb "generate-invoice"
| Project Stats | `/api/ProjectStats/{projectId}` | `/api/projects/{projectId}/statistics` | GET | Added `/statistics` to avoid conflict with `Get Project`
| Manager Stats | `/api/ProjectStats/manager/{managerId}` | `/api/projects/manager/{managerId}/statistics` | GET |

* Base Route for Labels: `api/labels`
| Action | Old URL | New URL | HTTP Method |
| :--- | :--- | :--- | :--- |
| Create Label | `/api/Label` | `/api/labels` | POST |
| Update Label | `/api/Label/{id}` | `/api/labels/{id}` | PUT |
| Delete Label | `/api/Label/{id}` | `/api/labels/{id}` | DELETE |

## 4. Task & Annotation (`TaskController`)
* Base Route: `api/tasks`
| Action | Old URL | New URL | HTTP Method | Note |
| :--- | :--- | :--- | :--- | :--- |
| Assign Tasks | `/api/Task/assign` | `/api/tasks/assign` | POST |
| Tasks By Bucket| `/api/Task/project/{projectId}/bucket/{bucketId}` | `/api/tasks/project/{projectId}/bucket/{bucketId}` | GET |
| My Projects | `/api/Task/my-projects` | `/api/tasks/my-projects` | GET |
| Batch Submit | `/api/Task/submit-multiple` | `/api/tasks/batch-submit` | POST | Changed `submit-multiple` to `batch-submit`
| Project Images | `/api/Task/project/{projectId}/images` | `/api/tasks/project/{projectId}/images` | GET |
| Jump To Image | `/api/Task/project/{projectId}/jump/{dataItemId}` | `/api/tasks/project/{projectId}/jump/{dataItemId}` | GET |
| Single Assign | `/api/Task/assignment/{id}` | `/api/tasks/assignment/{id}` | GET |
| Save Draft | `/api/Task/save-draft` | `/api/tasks/draft` | POST | Changed `save-draft` to `draft`
| Submit Task | `/api/Task/submit` | `/api/tasks/submit` | POST |

## 5. Review & QA (`ReviewController`)
* Base Route: `api/reviews`
| Action | Old URL | New URL | HTTP Method |
| :--- | :--- | :--- | :--- |
| My Projects | `/api/Review/projects` | `/api/reviews/projects` | GET |
| Submit Review | `/api/Review/submit` | `/api/reviews/submit` | POST |
| Audit Review | `/api/Review/audit` | `/api/reviews/audit` | POST |
| Pending Tasks | `/api/Review/project/{projectId}` | `/api/reviews/project/{projectId}` | GET |

## 6. Dispute & Logs (`DisputeController` & `ActivityLogController`)
* Dispute Route: `api/disputes`
| Action | Old URL | New URL | HTTP Method |
| :--- | :--- | :--- | :--- |
| Create Dispute | `/api/Dispute` | `/api/disputes` | POST |
| Resolve Dispute| `/api/Dispute/resolve` | `/api/disputes/resolve` | POST |
| Get Disputes | `/api/Dispute` | `/api/disputes` | GET |

* Activity Logs Route: `api/activity-logs`
| Action | Old URL | New URL | HTTP Method |
| :--- | :--- | :--- | :--- |
| System Logs | `/api/logs/system` | `/api/activity-logs/system` | GET |
| Project Logs | `/api/logs/project/{projectId}` | `/api/activity-logs/project/{projectId}` | GET |
