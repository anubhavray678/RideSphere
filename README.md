# 🚗 RideSphere – Scalable Ride-Sharing System (LLD + DSA + OOPs)

**RideSphere** is a console-based simulation of a scalable ride-sharing platform (like Uber or Ola) built in **C#**.  
It showcases **Low-Level Design (LLD)**, **Object-Oriented Programming (OOPs)**, and **core DSA algorithms** such as **KNN**, **Haversine Distance**, and **Dijkstra’s Shortest Path**.

---

## 🧠 Tech & Concepts
- **Language:** C# (.NET 8 Console Application)
- **Architecture:** Modular, Object-Oriented Design
- **Algorithms Implemented:**
  - **KNN (K-Nearest Neighbors):** Finds nearest available drivers efficiently
  - **Haversine Formula:** Calculates real-world geo-distance between coordinates
  - **Dijkstra’s Algorithm:** Determines the shortest route between pickup and drop
- **Design Patterns Used:** Strategy, Singleton, and Factory
- **Key Components:** Surge pricing, driver availability, and route optimization

---

## 📂 Project Structure
RideSphere/
├── Models/
│ ├── Driver.cs
│ ├── Rider.cs
│ └── Location.cs
├── Algorithms/
│ ├── DistanceCalculator.cs
│ ├── KNNFinder.cs
│ └── Dijkstra.cs
├── Services/
│ ├── RideService.cs
│ ├── SurgePricingService.cs
│ └── RouteService.cs
└── Program.cs



---

## ⚙️ Core Features

| Feature | Description |
|----------|--------------|
| 🚙 **Driver-Rider Matching** | Uses **KNN** to find the top nearest drivers by distance. |
| 🗺️ **Shortest Route Optimization** | Implements **Dijkstra’s Algorithm** to suggest best routes. |
| 💰 **Dynamic Pricing** | Integrates surge pricing using **Strategy Pattern**. |
| 🔄 **Ride Lifecycle Management** | Includes booking, assignment, and completion flow. |

---

## 🧩 Sample Console Output
🚗 Ride Confirmed:
Driver: Rahul Sharma
Distance: 6.24 km
Surge Factor: x1.25
Total Fare: ₹122.50


---

## 🚀 How to Run

1. **Clone the repository**
   ```bash
   git clone https://github.com/anubhavray678/RideSphere.git



