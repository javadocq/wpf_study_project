# 🚀 .NET 10.0 WPF Study Repository

이 저장소는 **.NET 10.0** 환경에서 C#과 WPF(Windows Presentation Foundation)를 학습하며 제작한 프로젝트들을 하나로 관리하는 통합 레포지토리입니다.

---

## 📂 프로젝트 구성 (Included Projects)

| 프로젝트 명 | 핵심 기능 | 기술 스택 | 폴더 링크 |
|:--- |:--- |:--- |:--- |
| **WPF Calculator** | 기본적인 사칙연산 및 레이아웃 구성 | Grid, StackPanel, Events | [이동](./wpf_calculator_app) |
| **Desktop Contacts** | SQLite DB 연동 연락처 CRUD 관리 | **SQLite-net-pcl**, LINQ | [이동](./wpf_desktop_contacts_app) |
| **Weather App** | 실시간 OpenWeather API 날씨 조회 | HttpClient, JSON Parsing | [이동](./wpf_weather_app) |

---

## 🛠 Tech Stack

* **Framework:** .NET 10.0 (WPF)
* **Language:** C# 14.0
* **Database:** SQLite (Local)
* **Development Tool:** Visual Studio 2026

---

## ⚙️ 실행 방법 (How to Run)

1.  **저장소 클론**
    ```bash
    git clone [https://github.com/사용자이름/wpf_study_project.git](https://github.com/사용자이름/wpf_study_project.git)
    ```
2.  **종속성 복구**
    각 프로젝트 폴더에서 NuGet 패키지를 복구합니다. (Visual Studio에서 열면 자동 실행)
3.  **프로젝트 실행**
    원하는 프로젝트의 `.csproj` 파일을 실행하거나, 통합 솔루션(`.sln`)을 통해 빌드합니다.

---
