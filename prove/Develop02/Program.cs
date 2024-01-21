import random
import datetime

class Entry:
    def __init__(self, prompt, response, date):
        self.prompt = prompt
        self.response = response
        self.date = date

class Journal:
    def __init__(self):
        self.entries = []

    def add_entry(self, entry):
        self.entries.append(entry)

    def display_entries(self):
        for entry in self.entries:
            print(f"\nDate: {entry.date}\nPrompt: {entry.prompt}\nResponse: {entry.response}")

    def save_to_file(self, filename):
        with open(filename, "w") as file:
            for entry in self.entries:
                file.write(f"{entry.date}, {entry.prompt}, {entry.response}\n")

    def load_from_file(self, filename):
        self.entries = []
        with open(filename, "r") as file:
            for line in file:
                date, prompt, response = line.strip().split(', ')
                self.entries.append(Entry(prompt, response, date))

class Program:
    def __init__(self):
        self.journal = Journal()
        self.prompts = [
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        ]

    def write_new_entry(self):
        prompt = random.choice(self.prompts)
        response = input(f"{prompt}\nYour response: ")
        date = datetime.datetime.now().strftime("%Y-%m-%d")
        entry = Entry(prompt, response, date)
        self.journal.add_entry(entry)

    def display_journal(self):
        self.journal.display_entries()

    def save_journal(self):
        filename = input("Enter the filename to save the journal: ")
        self.journal.save_to_file(filename)

    def load_journal(self):
        filename = input("Enter the filename to load the journal from: ")
        self.journal.load_from_file(filename)

    def run(self):
        while True:
            print("\n1. Write a new entry")
            print("2. Display the journal")
            print("3. Save the journal to a file")
            print("4. Load the journal from a file")
            print("5. Quit")

            choice = input("Enter your choice (1-5): ")

            if choice == "1":
                self.write_new_entry()

            elif choice == "2":
                self.display_journal()

            elif choice == "3":
                self.save_journal()

            elif choice == "4":
                self.load_journal()

            elif choice == "5":
                break

if __name__ == "__main__":
    program = Program()
    program.run()
