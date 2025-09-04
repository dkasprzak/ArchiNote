import { Backdrop, CircularProgress } from "../../assets/theme/components";

export const Loader = ({ show }: { show: boolean }) => {
  return (
    <div>
      <Backdrop
        sx={(theme) => ({ color: "#fff", zIndex: theme.zIndex.drawer + 1 })}
        open={show}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
    </div>
  );
};
