class My:
    age = 1

    def __init__(self):
        self.name = None

    def say_name(self):
        print(self.name)


if __name__ == '__main__':
    def foryield():
        print("start test yield")
        while True:
            result = yield 5
            print("result:", result)


    g = foryield()
    print(next(g))
    print("*" * 20)
    print(next(g))
    print(next(g))
