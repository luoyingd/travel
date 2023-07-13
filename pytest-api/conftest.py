import time


def pytest_terminal_summary(terminalreporter):
    print(terminalreporter.stats)
    print("total：", terminalreporter._numcollected)
    print('passed：', len([i for i in terminalreporter.stats.get('passed', []) if i.when != 'teardown']))
    print('failed：', len([i for i in terminalreporter.stats.get('failed', []) if i.when != 'teardown']))
    print('error：', len([i for i in terminalreporter.stats.get('error', []) if i.when != 'teardown']))
    print('skipped：', len([i for i in terminalreporter.stats.get('skipped', []) if i.when != 'teardown']))
    print('success rate：%.2f' % (len(terminalreporter.stats.get('passed', [])) / terminalreporter._numcollected * 100) + '%')
    duration = time.time() - terminalreporter._sessionstarttime
    print('total times：', duration, 'seconds')