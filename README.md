Finance Management System in C#
Overview
This project is a Finance Management System implemented in C#. It allows users to manage their finances through two account types: Current Account and Savings Account. The system provides functionalities such as deposits, 
withdrawals, transfers, and transaction history management.

Features
Current Account Management:

Create a Current Account.
Deposit and withdraw money.
Transfer funds to another account.
View account details and transaction history.
Savings Account Management:

Create a Savings Account.
Deposit money with interest applied automatically.
View account details and transaction history.
General Features:

Secure input handling with validation.
Transaction history tracking.
Simple menu-driven navigation.
Getting Started
Prerequisites
.NET Framework or .NET Core SDK installed.
A code editor such as Visual Studio or Visual Studio Code.

Installation
Clone this repository:
git clone https://github.com/yourusername/FinanceManagementCSharp.git
Open the project in your preferred IDE.
Build the solution to restore dependencies.
Run the application.

Usage
Launch the application.
Follow the menu prompts to create accounts, deposit, withdraw, transfer funds, and view transaction history.

Project Structure
The project is organized as follows:

Program.cs: Entry point of the application. Manages the main menu and user flow.
Account.cs: Abstract class defining the basic structure of an account.
CurrentAccount.cs: Inherits from Account, represents a current account.
SavingsAccount.cs: Inherits from Account, represents a savings account with interest.
Transaction.cs: Represents a single transaction with description, amount, and date.
MenuHandler.cs: Handles the display and logic of menus.
SafeInput.cs: Provides secure input methods with validation.

Example Transactions
Creating a Current Account:
Enter your name when prompted.
Your account number will be generated automatically.
Depositing Money:
Navigate to the account menu.
Select the deposit option and enter the amount.
Transferring Funds:
Enter the target account number and the transfer amount.
Funds are securely transferred with both accounts updated.
Viewing Transactions:
Select the transaction history option to view all account transactions.

Future Enhancements
Integration with a database for persistent storage.
User authentication and login functionality.
Enhanced reporting and analytics.

Contributing
Contributions are welcome! Please fork the repository, create a feature branch, and submit a pull request.
