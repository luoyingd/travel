import json

import requests
import json as myJson
from common.logger import logger


class RestClient:

    def __init__(self, api_root_url):
        self.api_root_url = api_root_url
        self.session = requests.session()

    def get(self, url, params=None, headers=None):
        return self.request(url, "GET", params=params, headers=headers)

    def post(self, url, data=None, headers=None):
        return self.request(url, "POST", data=data, headers=headers)

    def put(self, url, data=None, headers=None):
        return self.request(url, "PUT", data=data, headers=headers)

    def delete(self, url, headers=None, params=None):
        return self.request(url, "DELETE", headers=headers, params=params)

    def request(self, url, method, data=None, params=None, headers=None):
        url = self.api_root_url + url
        self.print_request_log(url=url, method=method, data=data, headers=headers, params=params)
        if method == "GET":
            return self.session.get(url, params=params, headers=headers)
        if method == "POST":
            return requests.post(url, data=json.dumps(data), headers=headers)
        if method == "PUT":
            return self.session.put(url, data=json.dumps(data), headers=headers)
        if method == "DELETE":
            return self.session.delete(url, headers=headers, params=params)

    def print_request_log(self, url, method, data=None, params=None, headers=None, files=None, cookies=None):
        logger.info("URl ==>> {}".format(url))
        logger.info("Method ==>> {}".format(method))
        # Python3中，json在做dumps操作时，会将中文转换成unicode编码，因此设置 ensure_ascii=False
        logger.info("Head ==>> {}".format(myJson.dumps(headers, indent=4, ensure_ascii=False)))
        logger.info("Param ==>> {}".format(myJson.dumps(params, indent=4, ensure_ascii=False)))
        logger.info("Data ==>> {}".format(myJson.dumps(data, indent=4, ensure_ascii=False)))
        logger.info("Files ==>> {}".format(files))
        logger.info("Cookies ==>> {}".format(myJson.dumps(cookies, indent=4, ensure_ascii=False)))

