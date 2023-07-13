from api.user import user
from common.logger import logger
import json as myJson


def register_user(email=None, firstName=None, lastName=None, password=None):
    payload = {
        "email": email,
        "firstName": firstName,
        "lastName": lastName,
        "password": password
    }
    headers = {
        "Content-Type": "application/json"
    }
    res = user.register(data=payload, headers=headers)
    logger.info("register user ==>> response result ==>> {}".format(res.text))
    json = myJson.loads(res.text)
    return json.get("code")

def login_user(email=None, password=None, isFromGoogle=False):
    payload = {
        "email": email,
        "password": password,
        "isFromGoogle" : isFromGoogle
    }
    headers = {
        "Content-Type": "application/json"
    }
    res = user.login(data=payload, headers=headers)
    logger.info("register user ==>> response result ==>> {}".format(res.text))
    json = myJson.loads(res.text)
    return json.get("code"), json.get("data")
