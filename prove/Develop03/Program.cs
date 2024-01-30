import random

class Word:
    def __init__(self, text):
        self.text = text

    def hide(self):
        return '*' * len(self.text)

class Reference:
    def __init__(self, book, chapter, start_verse, end_verse=None):
        self.book = book
        self.chapter = chapter
        self.start_verse = start_verse
        self.end_verse = end_verse

    def __str__(self):
        if self.end_verse:
            return f"{self.book} {self.chapter}:{self.start_verse}-{self.end_verse}"
        else:
            return f"{self.book} {self.chapter}:{self.start_verse}"

class Scripture:
    def __init__(self, reference, text):
        self.reference = reference
        self.words = [Word(word) for word in text.split()]

    def hide_words(self):
        hidden_indices = set()

        while len(hidden_indices) < len(self.words):
            index = random.randint(0, len(self.words) - 1)
            hidden_indices.add(index)

        for index in hidden_indices:
            self.words[index] = Word(self.words[index].hide())

    def is_all_hidden(self):
        return all(word.text.startswith('*') for word in self.words)

    def display(self):
        hidden_scripture = ' '.join([word.text for word in self.words])
        print(f"{self.reference} - {hidden_scripture}")

class Program:
    @staticmethod
    def main():
        scripture_reference = Reference(book="John", chapter=3, start_verse=16)
        scripture_text = "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life."
        scripture = Scripture(reference=scripture_reference, text=scripture_text)

        while not scripture.is_all_hidden():
            input("Press Enter to continue or type 'quit' to exit: ")

            user_input = input().lower()
            if user_input == 'quit':
                break

            Program.console_clear()
            scripture.hide_words()
            scripture.display()

        print("Program ended.")

    @staticmethod
    def console_clear():
        print("\033c", end="")  # ANSI escape code to clear console

if __name__ == "__main__":
    Program.main()
