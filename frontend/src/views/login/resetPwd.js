import * as React from "react";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import OutlinedInput from "@mui/material/OutlinedInput";
import InputLabel from "@mui/material/InputLabel";
import FormControl from "@mui/material/FormControl";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import { http } from "../../utils/http";
import history from "../../utils/history";
import { message } from "antd";
function SendResetMail() {
  const [validate, setValidate] = React.useState(true);
  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    if (!data.get("email")) {
      setValidate(false);
      return;
    }
    setValidate(true);
    http
      .post("/user/sendResetMail", { email: data.get("email") })
      .then((res) => {
        message.success("We have sent a email to you. Please reset within 30 minutes.")
        history.push("/confirmResetPwd");
      })
      .catch((err) => {});
  };
  return (
    <section class="page-section-login" id="services">
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5" style={{ color: "white" }}>
            Reset Password
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit}
            noValidate
            sx={{ mt: 1, marginTop: 2 }}
          >
            <FormControl
              fullWidth
              sx={{ m: 1 }}
              style={{ backgroundColor: "white" }}
              required
              error={!validate}
            >
              <InputLabel htmlFor="outlined-adornment-amount">
                Email Address
              </InputLabel>
              <OutlinedInput
                id="outlined-adornment-amount"
                label="email"
                name="email"
              />
            </FormControl>

            <Button
              type="submit"
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
              style={{ marginLeft: 5 }}
              fullWidth
            >
              Submit
            </Button>
            <Grid container>
              <Grid item xs>
                <Link href="/confirmResetPwd" variant="body2">
                  Already sent request?
                </Link>
              </Grid>
              <Grid item>
                <Link href="/login" variant="body2">
                  Login
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </section>
  );
}

export default SendResetMail;
