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
        res_code, res_data = login_user(email, password, False)
        assert res_code == code
        assert res_data["token"] != ''
        logger.info("*************** end  test_register_user***************")

    @pytest.mark.parametrize("email, firstName, lastName, password, code",
                             user_login_data["test_register_user_duplicate"])
    def test_register_user_2(self, email, firstName, lastName, password, code):
        logger.info("*************** start test_register_user_duplicate ***************")
        logger.info("step 1 ==>> register user：{}".format(firstName))
        res_code = register_user(email, firstName, lastName, password)
        assert res_code == code
        logger.info("*************** end  test_register_user_duplicate ***************")


if __name__ == '__main__':
    pass
