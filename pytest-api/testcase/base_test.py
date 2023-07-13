import os

from common.read_data import data

BASE_PATH = os.path.dirname(os.path.dirname(os.path.realpath(__file__)))


def get_data(yaml_file_name):
    try:
        data_file_path = os.path.join(BASE_PATH, "data", yaml_file_name)
        yml_data = data.load_yaml(data_file_path)
    except Exception as ex:
        pass
    else:
        return yml_data


user_login_data = get_data("user/login.yml")

