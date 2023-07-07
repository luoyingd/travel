import * as React from "react";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import { TextField } from "@mui/material";
import { http } from "../../utils/http";
import history from "../../utils/history";
import { message } from "antd";
function ConfirmResetPwd() {
  // TODO:
  const [emailValidate, setEmailValidate] = React.useState(true);
  const [pwdValidate, setPwdValidate] = React.useState(true);
  const [tokenValidate, setTokenValidate] = React.useState(true);
  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    if (!data.get("email")) {
      setEmailValidate(false);
      return;
    }
    setEmailValidate(true);
    if (!data.get("password")) {
      setPwdValidate(false);
      return;
    }
    setPwdValidate(true);
    if (!data.get("token")) {
      setTokenValidate(false);
      return;
    }
    setTokenValidate(true);
    http
      .post("/user/resetPassword", {
        email: data.get("email"),
        token: data.get("token"),
        newPassword: data.get("password"),
      })
      .then((res) => {
        message.success("Successfully reset!");
        history.push("/login");
      })
      .catch((err) => {});
  };
  return (
    <section class="page-section-login" id="services">
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 4,
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
            sx={{ mt: 1 }}
          >
            <Grid container spacing={2}>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  id="email"
                  label="Email Address"
                  name="email"
                  autoComplete="email"
                  error={!emailValidate}
                  style={{ backgroundColor: "white" }}
                  variant="filled"
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  id="token"
                  label="Token"
                  name="token"
                  autoComplete="token"
                  error={!tokenValidate}
                  style={{ backgroundColor: "white" }}
                  variant="filled"
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  name="password"
                  label="Password"
                  type="password"
                  id="password"
                  autoComplete="password"
                  error={!pwdValidate}
                  style={{ backgroundColor: "white" }}
                  variant="filled"
                />
              </Grid>
            </Grid>
            <Button
              type="submit"
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
              fullWidth
            >
              Submit
            </Button>
            <Grid container>
              <Grid item xs>
                <Link href="/sendResetMail" variant="body2">
                  No valid token yet?
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

export default ConfirmResetPwd;
