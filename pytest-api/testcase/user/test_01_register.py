import datetime

import pytest
from operation.user import register_user, login_user
from testcase.base_test import user_login_data
from common.logger import logger


class TestUser:

    @pytest.mark.parametrize("firstName, lastName, password, code",
                             user_login_data["test_register_user_normal"])
    def test_register_user(self, firstName, lastName, password, code):
        logger.info("*************** start test_register_user***************")
        logger.info("step 1 ==>> register user：{}".format(firstName))
        t = int(datetime.datetime.now().timestamp())
        email = str(t) + "@gmail.com"
        res_code = register_user(email, firstName, lastName, password)
        assert res_code == code

        logger.info("step 2 ==>> login user：{}".format(firstName))
        res_code, res_data = login_user(email, password)
        assert res_code == code
        assert res_data["token"] != ''
        logger.info("*************** end  test_register_user***************")

    @pytest.mark.parametrize("email, firstName, lastName, password, code",
                             user_login_data["test_register_user_duplicate"])
    def test_register_user_duplicate(self, email, firstName, lastName, password, code):
        logger.info("*************** start test_register_user_duplicate ***************")
        logger.info("step 1 ==>> register user：{}".format(firstName))
        res_code = register_user(email, firstName, lastName, password)
        assert res_code == code
        logger.info("*************** end  test_register_user_duplicate ***************")

    @pytest.mark.parametrize("code",
                             user_login_data["test_user_empty"])
    def test_register_user_empty(self, code):
        logger.info("*************** start test_register_user_empty ***************")
        res_code = register_user()
        assert res_code == code
        logger.info("*************** end  test_register_user_empty ***************")

    @pytest.mark.parametrize("code",
                             user_login_data["test_user_empty"])
    def test_login_user_empty(self, code):
        logger.info("*************** start test_login_user_empty ***************")
        res_code, res_data = login_user()
        assert res_code == code
        logger.info("*************** end  test_login_user_empty ***************")

    @pytest.mark.parametrize("password, code",
                             user_login_data["test_login_user_wrong_username"])
    def test_login_user_wrong_username(self, password, code):
        logger.info("*************** start test_login_user_wrong_username ***************")
        t = int(datetime.datetime.now().timestamp())
        email = str(t) + "@gmail.com"
        res_code, res_data = login_user(password=password, email=email)
        assert res_code == code
        logger.info("*************** end  test_login_user_wrong_username ***************")

    @pytest.mark.parametrize("email, password, code",
                             user_login_data["test_login_user_wrong_password"])
    def test_login_user_wrong_password(self, email, password, code):
        logger.info("*************** start test_login_user_wrong_password ***************")
        res_code, res_data = login_user(password=password, email=email)
        assert res_code == code
        logger.info("*************** end  test_login_user_wrong_password ***************")


if __name__ == '__main__':
    pass
