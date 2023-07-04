import * as React from "react";
import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { TextField } from "@mui/material";
import loginStore from "../../stores/login/loginStore";
import { message } from "antd";
import { useNavigate } from "react-router-dom";
import history from "../../utils/history";
function Login() {
  const navigate = useNavigate();
  const [emailValidate, setEmailValidate] = React.useState(true);
  const [pwdValidate, setPwdValidate] = React.useState(true);
  const handleSubmit = async (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    const form = {
      email: data.get("email"),
      password: data.get("password"),
    };
    console.log(form);
    setEmailValidate(form.email != null && form.email != "");
    setPwdValidate(form.password != null && form.password != "");
    const result = await loginStore.login(form);
    if (result) {
      message.success("Successfully login!", [3]);
      history.push("/");
      window.location.reload();
    }
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
            Sign in
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit}
            noValidate
            sx={{ mt: 1 }}
            style={{ marginTop: 20 }}
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
              Sign In
            </Button>
            <Grid container>
              <Grid item xs>
                <Link href="/sendResetMail" variant="body2">
                  Forgot password?
                </Link>
              </Grid>
              <Grid item>
                <Link href="/signup" variant="body2">
                  {"Don't have an account? Sign Up"}
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </section>
  );
}

export default Login;
