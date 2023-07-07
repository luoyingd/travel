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
function SignUp() {
  const navigate = useNavigate();
  const [firstNameValidate, setFirstNameValidate] = React.useState(true);
  const [lastNameValidate, setLastNameValidate] = React.useState(true);
  const [emailValidate, setEmailValidate] = React.useState(true);
  const [pwdValidate, setPwdValidate] = React.useState(true);
  const handleSubmit = async (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    const form = {
      email: data.get("email"),
      password: data.get("password"),
      firstName: data.get("firstName"),
      lastName: data.get("lastName"),
    };
    console.log(form);
    setFirstNameValidate(form.firstName != null && form.firstName != "");
    setLastNameValidate(form.lastName != null && form.lastName != "");
    setEmailValidate(form.email != null && form.email != "");
    setPwdValidate(form.password != null && form.password != "");
    const result = await loginStore.register(form);
    if (result) {
      message.success("Successfully registered!", [3]);
      navigate("/login", { replace: true });
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
            Sign up
          </Typography>
          <Box
            component="form"
            noValidate
            onSubmit={handleSubmit}
            sx={{ mt: 3 }}
          >
            <Grid container spacing={2}>
              <Grid item xs={12} sm={6}>
                <TextField
                  autoComplete="given-name"
                  name="firstName"
                  required
                  fullWidth
                  id="firstName"
                  label="First Name"
                  autoFocus
                  style={{ backgroundColor: "white" }}
                  error={!firstNameValidate}
                  variant="filled"
                />
              </Grid>
              <Grid item xs={12} sm={6}>
                <TextField
                  required
                  fullWidth
                  id="lastName"
                  label="Last Name"
                  name="lastName"
                  autoComplete="family-name"
                  style={{ backgroundColor: "white" }}
                  error={!lastNameValidate}
                  variant="filled"
                />
              </Grid>
              <Grid item xs={12}>
                <TextField
                  required
                  fullWidth
                  id="email"
                  label="Email Address"
                  name="email"
                  autoComplete="email"
                  style={{ backgroundColor: "white" }}
                  error={!emailValidate}
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
                  style={{ backgroundColor: "white" }}
                  error={!pwdValidate}
                  variant="filled"
                />
              </Grid>
            </Grid>
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{ mt: 3, mb: 2 }}
            >
              Sign Up
            </Button>
            <Grid container justifyContent="flex-end">
              <Grid item>
                <Link href="/login" variant="body2">
                  Already have an account? Sign in
                </Link>
              </Grid>
            </Grid>
          </Box>
        </Box>
      </Container>
    </section>
  );
}

export default SignUp;
