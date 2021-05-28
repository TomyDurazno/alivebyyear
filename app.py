import json

fileName = "Data/Names with Dates.txt"
outputName = "Export/dataPy.json"

line = open(fileName, "r").readline()

elements = json.loads(line)


def byYear(people, year):
    alive = []
    for person in people:
        dates = person["Dates"]
        birthYear = int(dates["birth"].split("-")[0])
        deathYear = int(dates["death"].split("-")[0])

        if year >= birthYear and year <= deathYear:
            alive.append(person)
    return alive


dic = {}
for i in range(1900, 2001):
    dic[i] = len(byYear(elements, i))

with open(outputName, 'w') as f:
    json.dump(dic, f)
    
print("Success!!")
