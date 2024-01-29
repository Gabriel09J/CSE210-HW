import random

def hide_words(scripture):
    words = scripture.split()
    hidden_indices = set()

    while len(hidden_indices) < len(words):
        index = random.randint(0, len(words) - 1)
        hidden_indices.add(index)

    hidden_scripture = ' '.join(['*' * len(words[i]) if i in hidden_indices else words[i] for i in range(len(words))])
    return hidden_scripture

def main():
    scripture = {
        "reference": "John 3:16",
        "text": "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life."
    }

    while True:
        input("Press Enter to continue or type 'quit' to exit: ")
        
        if input().lower() == 'quit':
            break

        console_clear()
        hidden_scripture = hide_words(scripture["text"])
        print(f"{scripture['reference']} - {hidden_scripture}")

    print("Program ended.")

def console_clear():
    print("\033c", end="")  # ANSI escape code to clear console

if __name__ == "__main__":
    main()
