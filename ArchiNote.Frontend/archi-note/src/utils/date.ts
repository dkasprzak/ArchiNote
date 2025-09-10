export const formatDateAuto = (date: Date | string) => {
  const userLocale = navigator.language || "pl-PL";

  return new Date(date).toLocaleDateString(userLocale, {
    day: "2-digit",
    month: "2-digit",
    year: "numeric",
  });
};
