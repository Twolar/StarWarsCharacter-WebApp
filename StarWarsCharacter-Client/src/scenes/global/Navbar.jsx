import { Typography, Box } from "@mui/material";
import { useNavigate } from "react-router-dom";

const Navbar = () => {
  const navigate = useNavigate();

  return (
    <Box
      display="flex"
      justifyContent="space-between"
      p={2}
      borderBottom={0.5}
      marginBottom={2}
      boxShadow={1}
    >
      <Typography onClick={() => navigate("/")} style={{ cursor: "pointer" }}>
        <img
          src="/r2d2.svg"
          alt="R2D2 Icon"
          style={{ maxWidth: 20, marginRight: "8px" }}
        />
        StarWarsCharacterApp
      </Typography>
    </Box>
  );
};

export default Navbar;
