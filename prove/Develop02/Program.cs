import random
import datetime
import json

class JournalEntry:
    def __init__(self, prompt, response, date):
        self.prompt = prompt
        self.response = response
        self.date = date

class DailyJournal:
    def __init__(self):
        self.entries = []

    def write_new_entry(self):
        prompts = [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        ]
        prompt = random.choice(prompts)
        response = input(f"{prompt}\nYour response: ")
        date = datetime.date.today().strftime("%Y-%m-%d")
        entry = JournalEntry(prompt, response, date)
        self.entries.append(entry)
        print("\nEntry added successfully.")

    def display_journal(self):
        if not self.entries:
            print("No entries to display.")
        else:
            for entry in self.entries:
                print(f"\nDate: {entry.date}\nPrompt: {entry.prompt}\nResponse: {entry.response}")

    def save_to_file(self, filename):
        with open(filename, 'w') as file:
            entries_data = [{'prompt': entry.prompt, 'response': entry.response, 'date': entry.date} for entry in self.entries]
            json.dump(entries_data, file)
        print("\nJournal saved successfully.")

    def load_from_file(self, filename):
        try:
            with open(filename, 'r') as file:
                entries_data = json.load(file)
                self.entries = [JournalEntry(entry['prompt'], entry['response'], entry['date']) for entry in entries_data]
            print("\nJournal loaded successfully.")
        except FileNotFoundError:
            print("\nFile not found. Creating a new journal.")

def main():
    journal = DailyJournal()

    while True:
        print("\n1. Write a new entry\n2. Display the journal\n3. Save the journal to a file\n4. Load the journal from a file\n5. Exit")
        choice = input("Choose an option: ")

        if choice == '1':
            journal.write_new_entry()
        elif choice == '2':
            journal.display_journal()
        elif choice == '3':
            filename = input("Enter the filename to save the journal: ")
            journal.save_to_file(filename)
        elif choice == '4':
            filename = input("Enter the filename to load the journal: ")
            journal.load_from_file(filename)
        elif choice == '5':
            print("Exiting the program.")
            break
        else:
            print("Invalid choice. Please choose a valid option.")

if __name__ == "__main__":
    main()