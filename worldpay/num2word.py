"""
    Kaio Turubia - numbers to words  - 2016.06.01
"""

import os
# http://pt.wikipedia.org/wiki/Zetta
# http://pt.wikipedia.org/wiki/Escalas_curta_e_longa

from math import log

pattern = [
    (900, "nine hundred"), (800, "eight hundred"),
    (700, "seven hundred"), (600, "six hundred"),
    (500, "five hundred"), (400, "four hundred"),
    (300, "three hundred"), (200, "two hundred"),
    (100, "hundred"), (90, "ninety"),
    (80, "eighty"), (70, "seventy"),
    (60, "sixty"), (50, "fifty"),
    (40, "forty"), (30, "thirty"),
    (20, "twenty"), (19, "nineteen"),
    (18, "eighteen"), (17, "seventeen"),
    (16, "sixteen"), (15, "fifteen"),
    (14, "fourteen"), (13, "thirteen"),
    (12, "twelve"), (11, "eleven"),
    (10, "ten"), (9, "nine"),
    (8, "eight"), (7, "seven"),
    (6, "six"), (5, "five"),
    (4, "four"), (3, "three"),
    (2, "twoo"), (1, "one")]

shortScale = (
    (1, (" ", " ")),
    (2, ("thousand", "thousand")),
    (3, ("million", "millions")),
    (4, ("billion", "billions")),
    (5, ("trillion", "trillions")),
    (6, ("quadrillion", "quadrillions")),
    (7, ("quintillion", "quintillions")),
    (8, ("sextillion", "sextillions"))
)

def num2word(number):
    output = ""
    aux = False
    if number < 1000:
        output = write(number)
    else:
        # obtem a terna do número
        terns = []
        x = number
        while x >= 1:
            itemTern = x % 1000
            terns.append(int(itemTern))
            x /= 1000

        count = len(terns)

        for item in reversed([a for a in shortScale if a[0] <= count]):
            currIndex = count - 1
            currentTern = terns[currIndex]
            if currentTern == 0:
                count -= 1
                continue

            plural = (currentTern > 1)
            output += write(currentTern) + " " + (item[1][1] if plural else item[1][0]) + " "
            count -= 1

    print(output)


def write(number):
    strAux = ""
    divRest = ""
    if number == 0:
        strAux = "zero"
        return strAux

    while True:
        if number <= 20:
            strAux = findPattern(number);
            break

        if strAux == "" and divRest == "":
            strAux = findPattern(number)
            divRest = int(number % setNumber(number))
            aux = True
            if divRest == 0:
                break
        else:
            if aux == False:
                divRest = int(divRest % setNumber(divRest))
                if divRest == 0:
                    break
            else:
                divRest = divRest

            strAux += " and " + findPattern(divRest)
            aux = False

    return strAux


def findPattern(number):
    for item in pattern:
        value = item[0]
        if value == setNumber(number):
            return str(item[1])


def setNumber(number):
    strNum = ""
    if number > 19:
        for num in iter(str(number)):
            if strNum == "":
                strNum = num
            else:
                strNum += "0"
    else:
        strNum = number

    return int(strNum)


if __name__ == '__main__':
    number = input("choose a number please:")
    num2word(int(number))
