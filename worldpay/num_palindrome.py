"""
   Kaio Turubia - Palindrome Numbers  - 2016.06.01
"""
initial_number = input("choose a number please:")

def reverse(number):
    return int(str(number)[::-1])

def palindrome(number):
    return str(number) == str(reverse(number))

addition_times = 0
number = int(initial_number)

while True:
    addition_times += 1
    number += reverse(number)
    is_palindrome = palindrome(number)

    if is_palindrome:
        break

print(initial_number, addition_times, number)













